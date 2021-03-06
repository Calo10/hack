﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace x_devs_hacks.Models
{
    public class PickUpModel
    {
        public int id { get; set; }
        public int IdUser { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public string Status { get; set; }
        public DateTime Appointment { get; set; }

        List<PickUpModel> lstPickUps = new List<PickUpModel>();


        public PickUpModel() { }
        public PickUpModel(int id, int IdUser, string Description, string Image, double Lat, double Long, string Status, DateTime Appointment)
        {

            this.id = id;
            this.IdUser = IdUser;
            this.Description = Description;
            this.Image = Image;
            this.Lat = Lat;
            this.Long = Long;
            this.Status = Status;
            this.Appointment = Appointment;

        }

        public List<PickUpModel> getAllPickUps()
        {
            lstPickUps.Add(new PickUpModel
            {
                id = 1,
                IdUser = 3,
                Description = "Equipo de Computo comprendido por una impresa y varios tarros",
                Image = "",
                Lat = 9.902337,
                Long = -83.993116,
                Appointment = new DateTime(2016, 9, 10, 13, 0, 0),
                Status = "Pendiente"
                
            });

            lstPickUps.Add(new PickUpModel
            {
                id = 2,
                IdUser = 3,
                Description = "Desechos electronicos, entre ellos calculadores, monitores y varias mas....",
                Image = "",
                Lat = 9.902295,
                Long = -83.993669,
                Appointment = new DateTime(2016, 10, 11, 09, 0, 0),
                Status = "Pendiente"
            });

            lstPickUps.Add(new PickUpModel
            {
                id = 3,
                IdUser = 3,
                Description = "Equipo de computo y celulares con baterias entre otros",
                Image = "",
                Lat = 9.897588,
                Long = -83.996682,
                Appointment = new DateTime(2016, 9, 10, 13, 0, 0),
                Status = "Pendiente"
            });


            lstPickUps.Add(new PickUpModel
            {
                id = 4,
                IdUser = 3,
                Description = "Basura electronica, 5 computadoras y un horno de microhondas",
                Image = "",
                Lat = 9.909901,
                Long = -84.001295,
                Appointment = new DateTime(2016, 9, 10, 13, 0, 0),
                Status = "Pendiente"
            });


            lstPickUps.Add(new PickUpModel
            {
                id = 5,
                IdUser = 3,
                Description = "Monitores en mal estado de varios tamannos",
                Image = "",
                Lat = 9.909927,
                Long = -83.991339,
                Appointment = new DateTime(2016, 9, 10, 13, 0, 0),
                Status = "Pendiente"
            });

            return lstPickUps;

        }

        public void newPickUp(PickUpModel pPickUp) {

            lstPickUps.Add(pPickUp);

        }

    }
}