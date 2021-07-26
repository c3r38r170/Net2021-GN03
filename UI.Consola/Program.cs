using System;
using Business.Entities;

namespace UI.Consola {
	class Program {
		static void Main(string[] args) {
			new Usuarios().Menu();
		}
	}
	public class Usuarios {
		Business.Logic.UsuarioLogic UsuarioNegocio { set; get; }
		public Usuarios(){
			UsuarioNegocio = new Business.Logic.UsuarioLogic();
		}
		public void Menu() {
			ConsoleKeyInfo eleccion;
			do {
				Console.WriteLine(
					"1- Listado General" +
					"\n2- Consulta" +
					"\n3- Agregar" +
					"\n4- Modificar" +
					"\n5- Elimiar" +
					"\n6- Salir"
				);
				eleccion = Console.ReadKey();
				Console.Clear();
				switch (eleccion.Key) {
					case ConsoleKey.D1:
						ListadoGeneral();
						break;
					case ConsoleKey.D2:
						Consultar();
						break;
					case ConsoleKey.D3:
						Agregar();
						break;
					case ConsoleKey.D4:
						Modificar();
						break;
					case ConsoleKey.D5:
						Eliminar();
						break;
				}
			} while (eleccion.Key != ConsoleKey.D6);
		}
		void ListadoGeneral() {
			foreach (Usuario usr in UsuarioNegocio.GetAll())
				MostrarDatos(usr);
		}
		void MostrarDatos(Usuario usr) {
			Console.WriteLine("Usuario: {0}", usr.ID);
			Console.WriteLine("\t\tNombre: {0}", usr.Nombre);
			Console.WriteLine("\t\tApellido: {0}", usr.Apellido);
			Console.WriteLine("\t\tNombre de Usuario: {0}", usr.NombreUsuario);
			Console.WriteLine("\t\tClave: {0}", usr.Clave);
			Console.WriteLine("\t\tEmail; {0}", usr.Email);
			Console.WriteLine("\t\tHabilitado: {0}", usr.Habilitado);
			Console.WriteLine();
		}
		void Consultar() {
			try {
				Console.Clear();
				Console.Write("Ingrese el ID del usuario a consultar:");
				int ID = int.Parse(Console.ReadLine());
				this.MostrarDatos(UsuarioNegocio.GetOne(ID));
			} catch (FormatException fex) {
				Console.WriteLine();
				Console.WriteLine("La ID ingresada debe ser un numero entero");
			} catch (Exception ex) {
				Console.WriteLine();
				Console.WriteLine(ex.Message);
			} finally {
				Console.WriteLine("Presione una tecla para continuar");
				Console.ReadLine();
				Console.Clear();
			}
		}
    public void Agregar() {
      Usuario usuario = new Usuario();

      Console.Clear();
      Console.Write("Ingrese Nombre: ");
      usuario.Nombre = Console.ReadLine();
      Console.Write("Ingrese Apellido: ");
      usuario.Apellido = Console.ReadLine();
      Console.Write("Ingrese Nombre de Usuario: ");
      usuario.NombreUsuario = Console.ReadLine();
      Console.Write("Ingrese Clave: ");
      usuario.Clave = Console.ReadLine();
      Console.Write("Ingrese Email: ");
      usuario.Email = Console.ReadLine();
      Console.Write("Ingrese Habilitación de Usuario (1 - Si / Otro - No): ");
      usuario.Habilitado = (Console.ReadLine() == "1");
      usuario.State = BusinessEntity.States.New;
      UsuarioNegocio.Save(usuario);
      Console.WriteLine();
      Console.WriteLine("ID: {0}", usuario.ID);
    }
    public void Modificar() {
      try {
        Console.Clear();
        Console.Write("Ingrese el ID del usuario a modificar: ");
        int ID = int.Parse(Console.ReadLine());
        Usuario usuario = UsuarioNegocio.GetOne(ID);
        Console.Write("Ingrese Nombre: ");
        usuario.Nombre = Console.ReadLine();
        Console.Write("Ingrese Apellido: ");
        usuario.Apellido = Console.ReadLine();
        Console.Write("Ingrese Nombre de Usuario: ");
        usuario.NombreUsuario = Console.ReadLine();
        Console.Write("Ingrese Clave: ");
        usuario.Clave = Console.ReadLine();
        Console.Write("Ingrese Email: ");
        usuario.Email = Console.ReadLine();
        Console.Write("Ingrese Habilitación de Usuario (1 - Si / Otro - No): ");
        usuario.Habilitado = (Console.ReadLine() == "1");
        usuario.State = BusinessEntity.States.Modified;
        UsuarioNegocio.Save(usuario);
      } catch (FormatException fex) {
        Console.WriteLine();
        Console.WriteLine("La ID ingresada debe ser un número entero");
      } catch (Exception e) {
        Console.WriteLine();
        Console.WriteLine(e.Message);
      } finally {
        Console.WriteLine("Presione una tecla para continuar");
        Console.ReadKey();
      }
    }
    public void Eliminar() {
      try {
        Console.Clear();
        Console.WriteLine("Ingrese el ID del usuario a eliminar: ");
        int ID = int.Parse(Console.ReadLine());
        UsuarioNegocio.Delete(ID);
      } catch (FormatException fex) {
        Console.WriteLine();
        Console.WriteLine("La ID ingresada debe ser un número entero");
      } catch (Exception e) {
        Console.WriteLine();
        Console.WriteLine(e.Message);
      } finally {
        Console.WriteLine("Presione una tecla para continuar");
        Console.ReadKey();
      }
    }
  }
}
