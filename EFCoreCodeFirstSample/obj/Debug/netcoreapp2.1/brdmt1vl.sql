CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

CREATE TABLE "Employees" (
    "EmployeeId" bigserial NOT NULL,
    "FirstName" text NULL,
    "LastName" text NULL,
    "DateOfBirth" timestamp without time zone NOT NULL,
    "PhoneNumber" text NULL,
    "Email" text NULL,
    CONSTRAINT "PK_Employees" PRIMARY KEY ("EmployeeId")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20190207041326_EFCoreCodeFirstSample.Models.EmployeeContext', '2.1.4-rtm-31024');

ALTER TABLE "Employees" ADD "Active" boolean NOT NULL DEFAULT FALSE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20190207043052_EFCoreCodeFirstSample.Models.EmployeeContext_update', '2.1.4-rtm-31024');

ALTER TABLE "Employees" RENAME COLUMN "PhoneNumber" TO "MobilePhone";

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20190207043302_EFCoreCodeFirstSample.Models.EmployeeContext_update2', '2.1.4-rtm-31024');

ALTER TABLE "Employees" DROP COLUMN "MobilePhone";

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20190207043525_EFCoreCodeFirstSample.Models.EmployeeContext_update3', '2.1.4-rtm-31024');

