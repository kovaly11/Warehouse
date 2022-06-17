namespace Warehouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigrate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adres",
                c => new
                    {
                        AdresId = c.Int(nullable: false, identity: true),
                        Ulica = c.String(nullable: false, maxLength: 40),
                        NrBudynku = c.String(nullable: false, maxLength: 10),
                        KodPocztowy = c.String(maxLength: 10),
                        Miasto = c.String(nullable: false, maxLength: 40),
                        Kraj = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.AdresId);
            
            CreateTable(
                "dbo.Firma",
                c => new
                    {
                        FirmaId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false, maxLength: 40),
                        NIP = c.String(maxLength: 20),
                        OsobaKontaktowa = c.String(maxLength: 40),
                        Telefon = c.String(maxLength: 20),
                        StonaInternetowa = c.String(maxLength: 40),
                        AdresId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FirmaId)
                .ForeignKey("dbo.Adres", t => t.AdresId, cascadeDelete: true)
                .Index(t => t.AdresId);
            
            CreateTable(
                "dbo.Dokument",
                c => new
                    {
                        DokumentId = c.Int(nullable: false, identity: true),
                        PracownikId = c.Int(nullable: false),
                        FirmaId = c.Int(nullable: false),
                        DokumentDate = c.DateTime(nullable: false),
                        Typ = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DokumentId)
                .ForeignKey("dbo.Firma", t => t.FirmaId, cascadeDelete: true)
                .ForeignKey("dbo.Pracownik", t => t.PracownikId, cascadeDelete: true)
                .Index(t => t.PracownikId)
                .Index(t => t.FirmaId);
            
            CreateTable(
                "dbo.Pozycja",
                c => new
                    {
                        DokumentId = c.Int(nullable: false),
                        NrPozycji = c.Int(nullable: false),
                        TowarId = c.Int(nullable: false),
                        Ilosc = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DokumentId, t.NrPozycji })
                .ForeignKey("dbo.Dokument", t => t.DokumentId, cascadeDelete: true)
                .ForeignKey("dbo.Towar", t => t.TowarId, cascadeDelete: true)
                .Index(t => t.DokumentId)
                .Index(t => t.TowarId);
            
            CreateTable(
                "dbo.Towar",
                c => new
                    {
                        TowarId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false, maxLength: 40),
                        NrSerijny = c.String(nullable: false, maxLength: 20),
                        Wymiary = c.String(maxLength: 20),
                        Producent = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.TowarId);
            
            CreateTable(
                "dbo.Pracownik",
                c => new
                    {
                        PracownikId = c.Int(nullable: false, identity: true),
                        Imie = c.String(nullable: false, maxLength: 20),
                        Nazwisko = c.String(maxLength: 20),
                        Telefon = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.PracownikId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dokument", "PracownikId", "dbo.Pracownik");
            DropForeignKey("dbo.Pozycja", "TowarId", "dbo.Towar");
            DropForeignKey("dbo.Pozycja", "DokumentId", "dbo.Dokument");
            DropForeignKey("dbo.Dokument", "FirmaId", "dbo.Firma");
            DropForeignKey("dbo.Firma", "AdresId", "dbo.Adres");
            DropIndex("dbo.Pozycja", new[] { "TowarId" });
            DropIndex("dbo.Pozycja", new[] { "DokumentId" });
            DropIndex("dbo.Dokument", new[] { "FirmaId" });
            DropIndex("dbo.Dokument", new[] { "PracownikId" });
            DropIndex("dbo.Firma", new[] { "AdresId" });
            DropTable("dbo.Pracownik");
            DropTable("dbo.Towar");
            DropTable("dbo.Pozycja");
            DropTable("dbo.Dokument");
            DropTable("dbo.Firma");
            DropTable("dbo.Adres");
        }
    }
}
