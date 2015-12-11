namespace WeatherStationDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reset : DbMigration
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
                "dbo.Measurements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MeasurementTypeId = c.Int(nullable: false),
                        SensorId = c.Int(nullable: false),
                        MeasurementDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sensors", t => t.SensorId, cascadeDelete: true)
                .ForeignKey("dbo.MeasurementTypes", t => t.MeasurementTypeId, cascadeDelete: true)
                .Index(t => t.MeasurementTypeId)
                .Index(t => t.SensorId);
            
            CreateTable(
                "dbo.MeasurementTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sensors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.SensorMeasurementTypes",
                c => new
                    {
                        Sensor_Id = c.Int(nullable: false),
                        MeasurementType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Sensor_Id, t.MeasurementType_Id })
                .ForeignKey("dbo.Sensors", t => t.Sensor_Id, cascadeDelete: true)
                .ForeignKey("dbo.MeasurementTypes", t => t.MeasurementType_Id, cascadeDelete: true)
                .Index(t => t.Sensor_Id)
                .Index(t => t.MeasurementType_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TemperatureMeasurements", "Measurement_Id", "dbo.Measurements");
            DropForeignKey("dbo.HumidityMeasurements", "Measurement_Id", "dbo.Measurements");
            DropForeignKey("dbo.Measurements", "MeasurementTypeId", "dbo.MeasurementTypes");
            DropForeignKey("dbo.SensorMeasurementTypes", "MeasurementType_Id", "dbo.MeasurementTypes");
            DropForeignKey("dbo.SensorMeasurementTypes", "Sensor_Id", "dbo.Sensors");
            DropForeignKey("dbo.Measurements", "SensorId", "dbo.Sensors");
            DropIndex("dbo.SensorMeasurementTypes", new[] { "MeasurementType_Id" });
            DropIndex("dbo.SensorMeasurementTypes", new[] { "Sensor_Id" });
            DropIndex("dbo.TemperatureMeasurements", new[] { "Measurement_Id" });
            DropIndex("dbo.Measurements", new[] { "SensorId" });
            DropIndex("dbo.Measurements", new[] { "MeasurementTypeId" });
            DropIndex("dbo.HumidityMeasurements", new[] { "Measurement_Id" });
            DropTable("dbo.SensorMeasurementTypes");
            DropTable("dbo.TemperatureMeasurements");
            DropTable("dbo.Sensors");
            DropTable("dbo.MeasurementTypes");
            DropTable("dbo.Measurements");
            DropTable("dbo.HumidityMeasurements");
        }
    }
}
