/* Create Schema for Package Manager*/
BEGIN 
	EXECUTE IMMEDIATE 'DROP USER oci_pm CASCADE'; 
EXCEPTION 
	WHEN OTHERS THEN 
		dbms_output.put_line(to_char(SQLERRM)); 
END;
/

CREATE USER oci_pm IDENTIFIED BY "oci_pm";


