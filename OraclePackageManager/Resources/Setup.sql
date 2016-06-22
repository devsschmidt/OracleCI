/* Create Schema for Package Manager*/
BEGIN 
	EXECUTE IMMEDIATE 'DROP USER oci_pm CASCADE'; 
EXCEPTION 
	WHEN OTHERS THEN 
		dbms_output.put_line(to_char(SQLERRM)); 
END;
/

CREATE USER oci_pm IDENTIFIED BY "oci_pm";
GRANT CREATE SESSION TO oci_pm;
GRANT CREATE TABLE to oci_pm;
GRANT CREATE ANY PROCEDURE to oci_pm;
GRANT CREATE SEQUENCE  to oci_pm;
ALTER USER oci_pm QUOTA UNLIMITED ON USERS;

/* Execute as oci_pm */
DECLARE 
  l_count NUMBER;
BEGIN
  FOR sequence_name IN 
    (SELECT sequence_name AS name FROM user_sequences)
  LOOP
    EXECUTE IMMEDIATE 'DROP SEQUENCE '||sequence_name.name;
  END LOOP;
END;
/

DECLARE 
  l_count NUMBER;
BEGIN
  FOR tablename IN 
    (SELECT table_name AS abc FROM user_tables)
  LOOP
    EXECUTE IMMEDIATE 'DROP TABLE '||tablename.abc;
  END LOOP;
END;
/

CREATE TABLE connection (
  c_id VARCHAR2(36) NOT NULL,
  c_name VARCHAR2(255),
  c_tns VARCHAR2(255) NOT NULL,
  c_user VARCHAR(255) NOT NULL,
  c_password VARCHAR(255) NOT NULL,
  CONSTRAINT connection_pkey PRIMARY KEY (c_id)
);



CREATE TABLE realm (
  r_id VARCHAR2(36) NOT NULL,
  r_name VARCHAR2(255),
  CONSTRAINT realm_pkey PRIMARY KEY (r_id)
);

CREATE TABLE realm_connection(
  rc_realm_id VARCHAR2(36) NOT NULL,
  rc_connection_id VARCHAR2(36) NOT NULL,
  CONSTRAINT realm_connection_pkey PRIMARY KEY (rc_realm_id, rc_connection_id)
);

CREATE TABLE command_type(
  ct_id NUMBER(2) NOT NULL,
  ct_name VARCHAR2(20) NOT NULL,
  ct_sort_index NUMBER(2) NOT NULL,
  CONSTRAINT command_type_pkey PRIMARY KEY (ct_id)
);

INSERT INTO command_type VALUES (1,'PRE',1);
INSERT INTO command_type VALUES (2,'MAIN',2);
INSERT INTO command_type VALUES (3,'POST',3);

CREATE TABLE package(
  p_id VARCHAR2(36) NOT NULL,
  p_created TIMESTAMP DEFAULT SYSTIMESTAMP,
  p_last_modified TIMESTAMP DEFAULT SYSTIMESTAMP,
  p_name VARCHAR2(255) NOT NULL,
  CONSTRAINT package_pkey PRIMARY KEY (p_id)
);

CREATE TABLE command(
  c_id VARCHAR2(36) NOT NULL,
  c_package_id VARCHAR2(36) NOT NULL,
  c_type_id NUMBER(2) NOT NULL,
  c_created TIMESTAMP DEFAULT SYSTIMESTAMP,
  c_last_modified TIMESTAMP DEFAULT SYSTIMESTAMP,
  c_name VARCHAR2(255) NULL,
  c_value VARCHAR2(2000) NOT NULL,
  c_sort_index NUMBER(4) NOT NULL,
  CONSTRAINT command_pkey PRIMARY KEY (c_id)
);

CREATE TABLE deployment(
    d_id VARCHAR2(36) NOT NULL,
    d_package_id VARCHAR2(36) NOT NULL,
    d_created TIMESTAMP DEFAULT SYSTIMESTAMP,
    d_last_deployed TIMESTAMP,
    d_content CLOB,
    CONSTRAINT deployment_pkey PRIMARY KEY (d_id)
);

CREATE OR REPLACE PROCEDURE createDeploymentPackage(DeploymentId IN VARCHAR2, PackageId IN VARCHAR2, PackageContent VARCHAR2)
IS
    c_status_initial NUMBER;
BEGIN
    INSERT INTO deployment(d_id, d_package_id, d_content) 
    VALUES(DeploymentId, PackageId, PackageContent);
END;

INSERT INTO connection VALUES('a0154912-5f1a-47f7-b5bb-228f3be29c4d', 'STC@SQLVM for Development', 'SQLVM','stc', 'stc');
INSERT INTO realm VALUES('878176eb-3104-4977-a516-c6deca07fe5f', 'Local Realm');
INSERT INTO realm_connection VALUES('878176eb-3104-4977-a516-c6deca07fe5f', 'a0154912-5f1a-47f7-b5bb-228f3be29c4d');
INSERT INTO package VALUES('9e0b2d57-a63b-4493-91a7-7b0504a81923', SYSTIMESTAMP, SYSTIMESTAMP, 'My Package');
INSERT INTO command VALUES('bf20b8b6-17ac-4f1c-a3bc-8808e96ffafd','9e0b2d57-a63b-4493-91a7-7b0504a81923', 1, SYSTIMESTAMP, SYSTIMESTAMP, 'Drop Sequences', '
DECLARE 
  l_count NUMBER;
BEGIN
  FOR sequence_name IN 
    (SELECT sequence_name AS name FROM user_sequences)
  LOOP
    EXECUTE IMMEDIATE ''DROP SEQUENCE ''||sequence_name.name;
  END LOOP;
END
', 1);

INSERT INTO command VALUES('52a724c6-f238-4154-9503-ce911fa38fa0','9e0b2d57-a63b-4493-91a7-7b0504a81923', 1, SYSTIMESTAMP, SYSTIMESTAMP, 'Drop Sequences', '
DECLARE 
  l_count NUMBER;
BEGIN
  FOR tablename IN 
    (SELECT table_name AS abc FROM user_tables)
  LOOP
    EXECUTE IMMEDIATE ''DROP TABLE ''||tablename.abc;
  END LOOP;
END
', 2);

INSERT INTO command VALUES('7f301f66-af9c-42c3-a035-a804720fdfaa','9e0b2d57-a63b-4493-91a7-7b0504a81923', 2, SYSTIMESTAMP, SYSTIMESTAMP, 'Drop Sequences', '
CREATE TABLE event_type(
    et_id INTEGER NOT NULL,
    et_name VARCHAR2(40) NOT NULL,
    CONSTRAINT event_type_pkey PRIMARY KEY(et_id),
    CONSTRAINT event_type_name_unique UNIQUE (et_name)	
)
', 1);

INSERT INTO command VALUES('728d1793-4248-4476-ba83-dc25e8bbbe38','9e0b2d57-a63b-4493-91a7-7b0504a81923', 3, SYSTIMESTAMP, SYSTIMESTAMP, 'Drop Sequences', '
  INSERT INTO event_type VALUES(1,''USER_EVENT'')
', 1);
