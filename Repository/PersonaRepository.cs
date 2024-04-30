using jespinozaS5.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jespinozaS5.Repository
{
    public class PersonaRepository
    {
        string dbpath_;
        private SQLiteConnection conn_;
        public string statusMessage { get; set; }

        public void Init()
        {
            if(conn_ is not null)
                return;
            conn_ = new SQLiteConnection(dbpath_);
            conn_.CreateTable<Persona>();
        }
        public PersonaRepository(string dbpath)
        {
            dbpath_ = dbpath;
        }


        public void AddPersona(string name)
        {
            int result = 0;
            try
            {
                Init();

                if (string.IsNullOrEmpty(name))
                    throw new Exception("Nombre requerido");

                Persona persona = new Persona() { 
                Name = name,
                };
                result=conn_.Insert(persona);

                statusMessage = string.Format("Se ha agregado {0} registros, Nombre {1}", result, name);

            }
            catch (Exception ex)
            {

                statusMessage = string.Format("No se pudo agregar el registro con nombre: {0}, Error: {1}", name, ex.Message);

            }
        }

        public List<Persona> ListarPersonas()
        {
            try
            {
                Init();

                return conn_.Table<Persona>().ToList();


            }
            catch (Exception ex)
            {

                statusMessage = string.Format("No se pudo obtener los registros {0}", ex.Message);

            }
            return new List<Persona>();
        }

    }
}
