namespace WeatherStationDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MeasurementTypesCanBelongToMultipleSensors : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MeasurementTypes", "Sensor_Id", "dbo.Sensors");
            DropIndex("dbo.MeasurementTypes", new[] { "Sensor_Id" });
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
            
            DropColumn("dbo.MeasurementTypes", "Sensor_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MeasurementTypes", "Sensor_Id", c => c.Int());
            DropForeignKey("dbo.SensorMeasurementTypes", "MeasurementType_Id", "dbo.MeasurementTypes");
            DropForeignKey("dbo.SensorMeasurementTypes", "Sensor_Id", "dbo.Sensors");
            DropIndex("dbo.SensorMeasurementTypes", new[] { "MeasurementType_Id" });
            DropIndex("dbo.SensorMeasurementTypes", new[] { "Sensor_Id" });
            DropTable("dbo.SensorMeasurementTypes");
            CreateIndex("dbo.MeasurementTypes", "Sensor_Id");
            AddForeignKey("dbo.MeasurementTypes", "Sensor_Id", "dbo.Sensors", "Id");
        }
    }
}
