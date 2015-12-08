namespace WeatherStationDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Measurements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MeasurementTypeId = c.Int(nullable: false),
                        SensorId = c.Int(nullable: false),
                        MeasurementDateTime = c.DateTime(nullable: false),
                        Humidity = c.Single(),
                        Temperature = c.Single(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MeasurementTypes", t => t.MeasurementTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Sensors", t => t.SensorId, cascadeDelete: true)
                .Index(t => t.MeasurementTypeId)
                .Index(t => t.SensorId);
            
            CreateTable(
                "dbo.MeasurementTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Sensor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sensors", t => t.Sensor_Id)
                .Index(t => t.Sensor_Id);
            
            CreateTable(
                "dbo.Sensors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MeasurementTypes", "Sensor_Id", "dbo.Sensors");
            DropForeignKey("dbo.Measurements", "SensorId", "dbo.Sensors");
            DropForeignKey("dbo.Measurements", "MeasurementTypeId", "dbo.MeasurementTypes");
            DropIndex("dbo.MeasurementTypes", new[] { "Sensor_Id" });
            DropIndex("dbo.Measurements", new[] { "SensorId" });
            DropIndex("dbo.Measurements", new[] { "MeasurementTypeId" });
            DropTable("dbo.Sensors");
            DropTable("dbo.MeasurementTypes");
            DropTable("dbo.Measurements");
        }
    }
}
