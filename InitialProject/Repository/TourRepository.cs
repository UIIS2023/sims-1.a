﻿using InitialProject.Domain.RepositoryInterfaces;
using InitialProject.Model;
using InitialProject.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repository
{
    public class TourRepository:ITourRepository
    {
        private const string FilePath = "../../../Resources/Data/tours.csv";
        

        private readonly Serializer<Tour> _serializer;
        

        private List<Tour> _tours;
       
        
        public TourRepository()
        {            
            _serializer = new Serializer<Tour>();
           
            _tours = _serializer.FromCSV(FilePath);          
        }        
        public List<Tour> GetAll()
        {
            return _serializer.FromCSV(FilePath); ;
        }
        public Tour Save(Tour tour)
        {
            tour.Id = NextId();
            _tours = _serializer.FromCSV(FilePath);
            _tours.Add(tour);
            _serializer.ToCSV(FilePath, _tours);
            return tour;
        }
        public int NextId()
        {
            _tours = _serializer.FromCSV(FilePath);
            if (_tours.Count < 1)
            {
                return 1;
            }
            return _tours.Max(c => c.Id) + 1;
        }
        public void Delete(Tour tour)
        {
            _tours = _serializer.FromCSV(FilePath);
            Tour founded = _tours.Find(c => c.Id == tour.Id);
            _tours.Remove(founded);
            _serializer.ToCSV(FilePath, _tours);
        }
        public Tour Update(Tour tour)
        {
            _tours = _serializer.FromCSV(FilePath);
            Tour current = _tours.Find(c => c.Id == tour.Id);
            int index = _tours.IndexOf(current);
            _tours.Remove(current);
            _tours.Insert(index, tour);       // keep ascending order of ids in file 
            _serializer.ToCSV(FilePath, _tours);
            return tour;
        }
        public Tour GetById(int id)
        {
            return _tours.Find(c => c.Id == id);
        }      
    }
}
