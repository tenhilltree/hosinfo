ATTACH DATABASE  "/Users/tenhill/test/dotnet/hosinfo/hos.db"  AS  "D" ;

CREATE TABLE "TreatRecord" (
    "ID" TEXT NOT NULL CONSTRAINT "PK_TreatRecord" PRIMARY KEY,
    "Code" TEXT NOT NULL,
    "Name" TEXT NOT NULL,
    "Age" INTEGER NOT NULL,
    "DoctorID" INTEGER NOT NULL,
    "MedicineID" TEXT NOT NULL,
    "ReleaseDate" TEXT NOT NULL,
    CONSTRAINT "FK_TreatRecord_Stuff_DoctorID" FOREIGN KEY ("DoctorID") REFERENCES "D.Stuff" ("ID") ON DELETE CASCADE,
    CONSTRAINT "FK_TreatRecord_Medicine_MedicineID" FOREIGN KEY ("MedicineID") REFERENCES "D.Medicine" ("ID") ON DELETE CASCADE
)