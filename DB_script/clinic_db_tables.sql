---------------------------------Sex--------------------------------------------
CREATE SEQUENCE sex_seq START WITH 1 INCREMENT BY 1;

CREATE TABLE sex
  (
    id int                    NOT NULL CONSTRAINT sex_id_pk PRIMARY KEY,
    code varchar2(50)         NOT NULL UNIQUE,
    name varchar2(50)         NOT NULL 
  );

 -------------------------Patients-----------------------------------------------
CREATE SEQUENCE patients_seq START WITH 1 INCREMENT BY 1;

CREATE TABLE patients
 (
    id int                       NOT NULL CONSTRAINT patients_pk PRIMARY KEY,
    mrn varchar2(50)             NOT NULL UNIQUE,
    first_name varchar2(50)      NOT NULL,    
    last_name varchar2(50)       NOT NULL,
    middle_name varchar2(50),
    ssn varchar2(11)             NOT NULL, -- CHECK (ssn LIKE '[0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9][0-9][0-9]') UNIQUE ,
    dob date                     NOT NULL,
    sex_id int                   NOT NULL   CONSTRAINT patients_sex_fk REFERENCES sex(id),                                                     
    dod date                            
  );
 
----------------------------Clinics--------------------------------------------- 
CREATE SEQUENCE clinics_seq   START WITH 1 INCREMENT BY 1;

CREATE TABLE clinics
 (
    id int                     NOT NULL CONSTRAINT clinics_pk PRIMARY KEY,
    code varchar2(50)          NOT NULL UNIQUE,
    name varchar2(50)          NOT NULL,
    address varchar2(100)      NOT NULL
 );
 
-------------------------------Doctors------------------------------------------
CREATE SEQUENCE doctors_seq START WITH 1 INCREMENT BY 1; 
 
CREATE TABLE doctors
 (
    id int                       NOT NULL CONSTRAINT doctors_pk PRIMARY KEY, --- Doctor may work in 1 clinic only !!!!! 
    code varchar2(50)            NOT NULL UNIQUE,
    first_name varchar2(50)      NOT NULL,    
    last_name varchar2(50)       NOT NULL,
    middle_name varchar2(50),
    clinic_id int                NOT NULL  CONSTRAINT doctors_clin_FK REFERENCES clinics(id)
 );

-------------------------------Apartments---------------------------------------
CREATE SEQUENCE apartments_seq  START WITH 1 INCREMENT BY 1;
 
CREATE TABLE apartments
 (
    id int                     NOT NULL CONSTRAINT apartments_pk PRIMARY KEY,
    clinic_id int              NOT NULL CONSTRAINT apartments_clin_fk REFERENCES clinics(id),
    room_id int                NOT NULL,
    bed_id int                 NOT NULL,
   
  CONSTRAINT apartment_un UNIQUE	(clinic_id, room_id, bed_id)
 );

-------------------------------------------Visits-------------------------------
CREATE SEQUENCE visits_seq START WITH 1 INCREMENT BY 1;

CREATE TABLE visits
 (
    id int                       NOT NULL CONSTRAINT visits_pk PRIMARY KEY,        
    billing_number varchar(10)   NOT NULL UNIQUE,
    patient_id int               NOT NULL CONSTRAINT visits_pat_fk REFERENCES patients(id),
    doctor_id int                NOT NULL CONSTRAINT visits_doc_fk REFERENCES doctors(id),
    apartment_id int             NOT NULL CONSTRAINT visits_apar_fk REFERENCES apartments(id)
 ); 

---------------------------------------Orders-----------------------------------
CREATE SEQUENCE orders_seq START WITH 1 INCREMENT BY 1;
  
CREATE TABLE orders
 (                    
    id int                        NOT NULL CONSTRAINT orders_pk PRIMARY KEY,
    order_number varchar(10)      NOT NULL UNIQUE,
    visit_id int                  NOT NULL CONSTRAINT orders_vis_fk REFERENCES visits(id),
    clinical_info varchar2(500)   NOT NULL 
 );

--------------------------------------Tubes-------------------------------------
CREATE SEQUENCE tubes_seq  START WITH 1 INCREMENT BY 1;

CREATE TABLE tubes
 (
    id int                      NOT NULL CONSTRAINT tubes_pk PRIMARY KEY,
    code varchar2(50)           NOT NULL UNIQUE,
    name varchar2(50)           NOT NULL,
    volume int                  NOT NULL
 );         


CREATE SEQUENCE concrete_tubes_seq START WITH 1 INCREMENT BY 1;
 
CREATE TABLE concrete_tubes
 (
    id int                      NOT NULL CONSTRAINT concrete_tubes_pk PRIMARY KEY ,
    code varchar2(50)           NOT NULL UNIQUE,
    order_id int                NOT NULL CONSTRAINT concrete_tubes_ord_fk REFERENCES orders(id),
    tube_id int                 NOT NULL CONSTRAINT concrete_tubes_tub_fk REFERENCES tubes(id),
    received_dt date            NOT NULL 
 ); 
  
 ---------------------------------Specimens-------------------------------------
CREATE SEQUENCE specimens_seq START WITH 1 INCREMENT BY 1;

CREATE TABLE specimens
 (
    id int                      NOT NULL CONSTRAINT specimens_pk PRIMARY KEY,
    code varchar2(50)           NOT NULL UNIQUE,   
    name varchar2(50)           NOT NULL,
    default_tube int            NOT NULL CONSTRAINT specimens_def_fk REFERENCES tubes(id)
 );


CREATE SEQUENCE concrete_specimens_seq START WITH 1 INCREMENT BY 1;

CREATE TABLE concrete_specimens
 (
    id int                     NOT NULL CONSTRAINT concrete_specimens_pk PRIMARY KEY,
    code varchar2(50)          NOT NULL UNIQUE,
    order_id int               NOT NULL CONSTRAINT concrete_specimens_ord_fk REFERENCES orders(id),
    specimen_id int            NOT NULL CONSTRAINT concrete_specimens_spec_fk REFERENCES specimens(id),
    collected_dt date          NOT NULL,
    volume int                 NOT NULL
 );
  
---------------------------------Tests------------------------------------------
CREATE SEQUENCE tests_seq START WITH 1 INCREMENT BY 1;
 
CREATE TABLE tests 
 (
    id int                     NOT NULL CONSTRAINT tests_pk PRIMARY KEY, 
    code varchar2(50)          NOT NULL UNIQUE,
    name varchar2(50)          NOT NULL,
    cost number                NOT NULL,                                     
    default_specimen_id int    NOT NULL CONSTRAINT tests_def_fk  REFERENCES specimens(id)
 );
 

CREATE SEQUENCE concrete_tests_seq START WITH 1 INCREMENT BY 1;

CREATE TABLE concrete_tests 
 (
    Id int                 NOT NULL CONSTRAINT concrete_tests_pk PRIMARY KEY,
    code varchar2(50)      NOT NULL UNIQUE,
    order_id int           NOT NULL CONSTRAINT concrete_tests_ord_fk REFERENCES orders(id),
    test_id int            NOT NULL CONSTRAINT concrete_tests_tes_fk REFERENCES tests(id),
    
  CONSTRAINT concrete_tests_un  UNIQUE (test_id, order_id)
 );
 
 --------------------------TestsTubesAttach-------------------------------------
CREATE SEQUENCE tests_tubes_attach_seq START WITH 1 INCREMENT BY 1;
 
CREATE TABLE tests_tubes_attach
 (
    Id int                   NOT NULL CONSTRAINT tests_tube_attach_pk PRIMARY KEY,
    test_id int              NOT NULL CONSTRAINT tests_tube_attach_tes_fk REFERENCES concrete_tests(id),
    tube_id int              NOT NULL CONSTRAINT tests_tube_attach_tub_fk REFERENCES concrete_tubes(id),
  
  CONSTRAINT tests_tube_attach_un  UNIQUE (test_id, tube_id) 
 );
 
 
----------------------------Indications----------------------------------------- 
CREATE SEQUENCE indications_seq START WITH 1 INCREMENT BY 1;

CREATE TABLE indications
 (
    id int                   NOT NULL   CONSTRAINT indications_pk PRIMARY KEY,
    code varchar2(50)        NOT NULL UNIQUE, 
    name varchar2(100)       NOT NULL
 );


CREATE SEQUENCE concrete_indications_seq START WITH 1 INCREMENT BY 1;

CREATE TABLE concrete_indications
 (
    id int                     NOT NULL   CONSTRAINT concrete_indications_pk PRIMARY KEY,
    code varchar2(50)          NOT NULL   UNIQUE, 
    order_id int               NOT NULL   CONSTRAINT concrete_indications_ord_fk REFERENCES orders(id),
    indication_id int          NOT NULL   CONSTRAINT concrete_indications_ind_fk REFERENCES indications(id),
  
  
  CONSTRAINT concrete_indications_un  UNIQUE (indication_id, order_id) 
 ); 
 
  --------------------------Diagnosis---------------------------------------------
CREATE SEQUENCE diagnosis_seq START WITH 1 INCREMENT BY 1;
 
CREATE TABLE diagnosis
 (
    id int                      NOT NULL CONSTRAINT diagnosis_pk PRIMARY KEY,
    code varchar2(50)           NOT NULL UNIQUE,
    Name varchar2(50)           NOT NULL
 );
  

CREATE SEQUENCE concrete_diagnosis_seq START WITH 1 INCREMENT BY 1;

CREATE TABLE concrete_diagnosis
 (
    id int                      NOT NULL  CONSTRAINT concrete_diagnosis PRIMARY KEY,
    code varchar2(50)           NOT NULL UNIQUE,
    order_id int                NOT NULL  CONSTRAINT concrete_diagnosis_ord_fk REFERENCES orders(id),
    diagnosis_id int            NOT NULL  CONSTRAINT concrete_diagnosis_diag_fk REFERENCES diagnosis(id),
  
  CONSTRAINT concrete_diagnosis_un  UNIQUE (diagnosis_id, order_id) 
 );
 
----------------------------TestSexAllowed------------------------------------
CREATE SEQUENCE tests_sex_allowed_seq START WITH 1 INCREMENT BY 1;

CREATE TABLE tests_sex_allowed 
 (
    id int                      NOT NULL CONSTRAINT tests_sex_allowed_pk PRIMARY KEY, 
    test_id int                 NOT NULL CONSTRAINT test_sex_allowed_tes_pk REFERENCES tests(id),
    sex_id int                  NOT NULL CONSTRAINT test_sex_allowed_sex_fk REFERENCES sex(id),
  
  CONSTRAINT tests_sex_allowed_un  UNIQUE (test_id, sex_id)
  );
  
------------------------------Inerpretetions------------------------------------
CREATE SEQUENCE interpretations_seq START WITH 1 INCREMENT BY 1;

CREATE TABLE interpretations
 (
    id int                         NOT NULL CONSTRAINT interpretations_pk PRIMARY KEY,
    order_id int                   NOT NULL CONSTRAINT interpretations_ord_fk REFERENCES orders(id),
    text varchar2(500)             NOT NULL,
    condition char(1)              NOT NULL CHECK (condition IN('n', 'a')), 
    sign_out_dt date               DEFAULT null
 );
---------------------------SpecimensTubesAttach-----------------------------------------------------
CREATE SEQUENCE specimens_tubes_attach_seq START WITH 1 INCREMENT BY 1;
 
CREATE TABLE specimens_tubes_attach
 (
    Id int                   NOT NULL CONSTRAINT specimens_tubes_attach_pk PRIMARY KEY,
    specimen_id int          NOT NULL CONSTRAINT specimens_tubes_attach_tes_fk REFERENCES concrete_specimens(id),
    tube_id int              NOT NULL CONSTRAINT specimens_tubes_attach_tub_fk REFERENCES concrete_tubes(id),
  
  CONSTRAINT specimens_tubes_attach_un  UNIQUE (specimen_id, tube_id) 
 );
 
