-------------------------sex_table_trigger-------------------------------------- 

CREATE OR REPLACE TRIGGER sex_tr 
   BEFORE INSERT ON sex
   FOR EACH ROW
     BEGIN
       SELECT sex_seq.NEXTVAL
       INTO   :new.id
       FROM   dual;
     END;
-------------------------patients_table_trigger---------------------------------

CREATE OR REPLACE TRIGGER patients_tr 
   BEFORE INSERT ON patients
   FOR EACH ROW
     BEGIN
       SELECT patients_seq.NEXTVAL
       INTO   :new.id
       FROM   dual;
     END;    
------------------------clinics_table_trigger-----------------------------------

CREATE OR REPLACE TRIGGER clinics_tr 
   BEFORE INSERT ON clinics
   FOR EACH ROW
     BEGIN
       SELECT clinics_seq.NEXTVAL
       INTO   :new.id
       FROM   dual;
     END; 
-----------------------doctors_table_trigger------------------------------------
 
CREATE OR REPLACE TRIGGER doctors_tr 
   BEFORE INSERT ON doctors
   FOR EACH ROW
     BEGIN
       SELECT doctors_seq.NEXTVAL
       INTO   :new.id
       FROM   dual;
     END;
---------------------apartments_table_trigger------------------------------------
 
CREATE OR REPLACE TRIGGER apartments_tr 
   BEFORE INSERT ON apartments
   FOR EACH ROW
     BEGIN
       SELECT apartments_seq.NEXTVAL
       INTO   :new.id
       FROM   dual;
     END;
---------------------visits_table_trigger---------------------------------------
CREATE OR REPLACE TRIGGER visits_tr 
   BEFORE INSERT ON visits
   FOR EACH ROW
     BEGIN
       SELECT visits_seq.NEXTVAL
       INTO   :new.id
       FROM   dual;
     END;
 
----------------------orders_table_trigger--------------------------------------

CREATE OR REPLACE TRIGGER orders_tr 
   BEFORE INSERT ON orders
   FOR EACH ROW
     BEGIN
       SELECT orders_seq.NEXTVAL
       INTO   :new.id
       FROM   dual;
     END;
----------------------tubes_table_trigger---------------------------------------
CREATE OR REPLACE TRIGGER tubes_tr 
   BEFORE INSERT ON tubes
   FOR EACH ROW
     BEGIN
       SELECT tubes_seq.NEXTVAL
       INTO   :new.id
       FROM   dual;
     END;
 
--------------------concrete_tubes_table_trigger--------------------------------

CREATE OR REPLACE TRIGGER concrete_tubes_tr 
   BEFORE INSERT ON concrete_tubes
   FOR EACH ROW
     BEGIN
       SELECT Tubes_seq.NEXTVAL
       INTO   :new.id
       FROM   dual;
     END;
--------------------specimens_table_trigger-------------------------------------

CREATE OR REPLACE TRIGGER specimens_tr 
   BEFORE INSERT ON specimens
   FOR EACH ROW
     BEGIN
       SELECT specimens_seq.NEXTVAL
       INTO   :new.id
       FROM   dual;
     END; 
------------------concrete_specimens_table_trigger------------------------------

CREATE OR REPLACE TRIGGER concrete_specimens_tr 
   BEFORE INSERT ON concrete_specimens
   FOR EACH ROW
     BEGIN
       SELECT concrete_specimens_seq.NEXTVAL
       INTO   :new.id
       FROM   dual;
     END;  
---------------------tests_table_trigger----------------------------------------

CREATE OR REPLACE TRIGGER tests_tr 
   BEFORE INSERT ON tests
   FOR EACH ROW
     BEGIN
       SELECT tests_seq.NEXTVAL
       INTO   :new.id
       FROM   dual;
     END;  
 
-------------------concrete_tests_table_trigger---------------------------------

CREATE OR REPLACE TRIGGER concrete_tests_tr 
   BEFORE INSERT ON concrete_tests
   FOR EACH ROW
     BEGIN
       SELECT concrete_tests_seq.NEXTVAL
       INTO   :new.id
       FROM   dual;
     END;   
---------------------indications_table_trigger----------------------------------

CREATE OR REPLACE TRIGGER indications_tr 
   BEFORE INSERT ON indications
   FOR EACH ROW
     BEGIN
       SELECT indications_seq.NEXTVAL
       INTO   :new.id
       FROM   dual;
     END;
----------------------concrete_indication_table_trigger-------------------------

CREATE OR REPLACE TRIGGER concrete_indications_tr 
   BEFORE INSERT ON concrete_indications
   FOR EACH ROW
     BEGIN
       SELECT concrete_indications_seq.NEXTVAL
       INTO   :new.id
       FROM   dual;
     END;
---------------------diagnosis_table_trigger------------------------------------ 

CREATE OR REPLACE TRIGGER diagnosis_tr 
   BEFORE INSERT ON diagnosis
   FOR EACH ROW
     BEGIN
       SELECT diagnosis_seq.NEXTVAL
       INTO   :new.id
       FROM   dual;
     END;
---------------------concrete_diagnosis_table_trigger---------------------------

CREATE OR REPLACE TRIGGER concrete_diagnosis_tr 
   BEFORE INSERT ON concrete_diagnosis
   FOR EACH ROW
     BEGIN
       SELECT concrete_diagnosis_seq.NEXTVAL
       INTO   :new.id
       FROM   dual;
     END; 
 
-----------------------interpretations_table_trigger--------------------------- 
 
CREATE OR REPLACE TRIGGER interpretations_tr 
   BEFORE INSERT ON interpretations
   FOR EACH ROW
     BEGIN
       SELECT interpretations_seq.NEXTVAL
       INTO   :new.id
       FROM   dual;
     END;
 
 --------------------tests_sex_allowed_trigger----------------------------------
 
 CREATE OR REPLACE TRIGGER tests_sex_allowed_tr 
   BEFORE INSERT ON tests_sex_allowed
   FOR EACH ROW
     BEGIN
       SELECT tests_sex_allowed_seq.NEXTVAL
       INTO   :new.id
       FROM   dual;
     END;
---------------------------tests_tubes_attach_trigger--------------------------- 
 CREATE OR REPLACE TRIGGER tests_tube_attach_tr 
   BEFORE INSERT ON tests_tubes_attach
   FOR EACH ROW
     BEGIN
       SELECT tests_tubes_attach_seq.NEXTVAL
       INTO   :new.id
       FROM   dual;
     END;
---------------------------specimens_tubes_attach_trigger-----------------------     
 CREATE OR REPLACE TRIGGER spec_tubes_attach_allowed_tr 
   BEFORE INSERT ON specimens_tubes_attach
   FOR EACH ROW
     BEGIN
       SELECT specimens_tubes_attach_seq.NEXTVAL
       INTO   :new.id
       FROM   dual;
     END;