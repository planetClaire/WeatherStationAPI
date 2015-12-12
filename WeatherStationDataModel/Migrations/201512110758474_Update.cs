namespace WeatherStationDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HumidityMeasurements", "Measurement_Id", "dbo.Measurements");
            DropForeignKey("dbo.TemperatureMeasurements", "Measurement_Id", "dbo.Measurements");
            DropIndex("dbo.HumidityMeasurements", new[] { "Measurement_Id" });
            DropIndex("dbo.TemperatureMeasurements", new[] { "Measurement_Id" });
            DropTable("dbo.HumidityMeasurements");
            DropTable("dbo.TemperatureMeasurements");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TemperatureMeasurements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Temperature = c.Single(nullable: false),
                        Measurement_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HumidityMeasurements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Humidity = c.Single(nullable: false),
                        Measurement_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.TemperatureMeasurements", "Measurement_Id");
            CreateIndex("dbo.HumidityMeasurements", "Measurement_Id");
            AddForeignKey("dbo.TemperatureMeasurements", "Measurement_Id", "dbo.Measurements", "Id");
            AddForeignKey("dbo.HumidityMeasurements", "Measurement_Id", "dbo.Measurements", "Id");
        }
    }
}
