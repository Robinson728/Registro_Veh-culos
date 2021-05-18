using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Registro_Vehículos.Models;
using Registro_Vehículos.DAL;

namespace Registro_Vehículos.BLL
{
    public class VehiculosBLL
    {
        public static bool Guardar(Vehiculos vehiculos)
        {
            if (!Existe(vehiculos.VehiculoId))
                return Insertar(vehiculos);
            else
                return Modificar(vehiculos);
        }

        private static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Vehiculos.Any(e => e.VehiculoId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        private static bool Insertar(Vehiculos vehiculos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Vehiculos.Add(vehiculos);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        private static bool Modificar(Vehiculos vehiculos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Entry(vehiculos).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                var vehiculos = contexto.Vehiculos.Find(id);

                if(vehiculos != null)
                {
                contexto.Vehiculos.Remove(vehiculos);
                paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Vehiculos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Vehiculos vehiculos;

            try
            {
                vehiculos = contexto.Vehiculos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return vehiculos;
        }

        public static List<Vehiculos> GetList(Expression<Func<Vehiculos, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Vehiculos> lista = new List<Vehiculos>();

            try
            {
                lista = contexto.Vehiculos.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }

        public static List<Vehiculos> GetVehiculos()
        {
            Contexto contexto = new Contexto();
            List<Vehiculos> lista = new List<Vehiculos>();

            try
            {
                lista = contexto.Vehiculos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
    }
}
