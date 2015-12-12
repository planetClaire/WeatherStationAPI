namespace WeatherStationDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAgain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HumidityMeasurements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Humidity = c.Single(nullable: false),
                        Measurement_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Measurements", t => t.Measurement_Id)
                .Index(t => t.Measurement_Id);
            
            CreateTable(
                "dbo.TemperatureMeasurements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Temperature = c.Single(nullable: false),
                        Measurement_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Measurements", t => t.Measurement_Id)
                .Index(t => t.Measurement_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TemperatureMeasurements", "Measurement_Id", "dbo.Measurements");
            DropForeignKey("dbo.HumidityMeasurements", "Measurement_Id", "dbo.Measurements");
            DropIndex("dbo.TemperatureMeasurements", new[] { "Measurement_Id" });
            DropIndex("dbo.HumidityMeasurements", new[] { "Measurement_Id" });
            DropTable("dbo.TemperatureMeasurements");
            DropTable("dbo.HumidityMeasurements");
        }
    }
}
