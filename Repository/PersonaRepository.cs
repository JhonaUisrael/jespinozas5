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


        public Persona BuscarPersonaPorId(int Id)
        {
            try
            {
                Init();

                return conn_.Table<Persona>().FirstOrDefault(p => p.Id == Id);


            }
            catch (Exception ex)
            {

                statusMessage = string.Format("No se pudo obtener los registros {0}", ex.Message);

            }
            return new Persona();
        }

        public void BorraPersona(int Id)
        {
            int result = 0;
            try
            {
                Init();

                result = conn_.Execute("DELETE FROM Persona WHERE Id = (?)", Id);

                statusMessage = string.Format("Se ha borrado {0} registro, Id {1}", result, Id);

            }
            catch (Exception ex)
            {

                statusMessage = string.Format("No se pudo borrar el registro con Id: {0}, Error: {1}", Id, ex.Message);

            }
        }

        public void ActualizarPersona(int Id,string nombre)
        {
            int result = 0;
            try
            {
                Init();
                Persona per = new();
                per.Id = Id;
                per.Name = nombre;
                result = conn_.Update(per);

                statusMessage = string.Format("Se ha actualizado {0} registro, Id {1}", result, Id);

            }
            catch (Exception ex)
            {

                statusMessage = string.Format("No se pudo actualizado el registro con Id: {0}, Error: {1}", Id, ex.Message);

            }
        }



    }
}
