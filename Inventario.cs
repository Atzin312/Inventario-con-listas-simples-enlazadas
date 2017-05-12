using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_de_Inventario
{
    class Inventario
    {
        Producto inicio;
        Producto temp;


        public Inventario()
        {
            inicio = null;
        }

        public void agreInicio(Producto nuevo)
        {
            bool bandera = true;
            if (inicio == null)
            {
                inicio = nuevo;
            }
            else
            {
                temp = inicio;
                //while (temp.siguiente != null)
                //{
                //    if (temp.codigo == nuevo.codigo)
                //    {
                //        bandera = false;
                //    }
                //    temp = temp.siguiente;
                //}
                if (Buscar(nuevo.codigo) ==null)// && temp.codigo != nuevo.codigo )//&& bandera)
                {
                    nuevo.siguiente = inicio;
                    inicio = nuevo;
                }
            }
        }

        public void agreFinal(Producto nuevo)
        {
            bool bandera = true;
            if (inicio == null)
            {
                inicio = nuevo;
            }
            else
            {
                temp = inicio;
                while (temp.siguiente != null)
                {
                    if (temp.codigo == nuevo.codigo)
                    {
                        bandera = false;
                    }
                    temp = temp.siguiente;
                }
                if (temp.codigo != nuevo.codigo && bandera)
                {
                    temp.siguiente = nuevo;
                }
            }
        }
        public void Agregar(Producto producto)
        {
            bool bandera = true;
            if (inicio == null)
            {
                inicio = producto;
            }
            else
            {
                temp = inicio;
                while (temp.siguiente != null)
                {
                    if (temp.codigo == producto.codigo)
                    {
                        bandera = false;
                    }
                    temp = temp.siguiente;
                }
                if (temp.codigo != producto.codigo && bandera)
                {
                    temp = inicio;
                    if (producto.codigo < temp.codigo)
                    {
                        producto.siguiente = temp;
                        inicio = producto;
                    }
                    else
                    {
                        bandera = true;
                        while (temp.siguiente != null)
                        {
                            if (producto.codigo < temp.siguiente.codigo)
                            {
                                producto.siguiente = temp.siguiente;
                                temp.siguiente = producto;
                                bandera = false;
                                break;
                            }
                            temp = temp.siguiente;
                        }
                        if (bandera)
                        {
                            temp.siguiente = producto;
                        }
                    }
                }
            }

        }

        public void Eliminar(int codigo)
        {
            temp = inicio;
            if (temp.codigo == codigo)
            {
                inicio = temp.siguiente;
            }
            else
            {
                while (temp.siguiente != null)
                {
                    if (temp.siguiente.codigo == codigo)
                    {
                        if (temp.siguiente.siguiente == null)
                        {
                            temp.siguiente = null;
                        }
                        else
                        {
                            temp.siguiente = temp.siguiente.siguiente;
                        }
                    }
                    if (temp.siguiente != null)
                    {
                        temp = temp.siguiente;
                    }
                }
            }
        }


        public Producto Buscar(int codigo)
        {
            temp = inicio;
            Producto producto = null;
            while (temp != null && producto==null)
            {
                if (temp.codigo == codigo)
                {
                    producto = temp;
                }
                temp = temp.siguiente;
            }
            return producto;
        }

        public string Reporte()
        {
            String datos = "";
            temp = inicio;
            while (temp != null)
            {
                datos += temp.ToString() + Environment.NewLine;
                temp = temp.siguiente;
            }
            return datos;
        }

        public String reporteInverso()
        {
            String inf = " ";
            String apoy;
            temp = inicio;
            while (temp != null)
            {
                apoy = temp.ToString() + Environment.NewLine;
                inf = apoy + inf;
                temp = temp.siguiente;
            }
            return inf;
        }


        public void insertar(Producto producto, int pos)
        {
            temp = inicio;
            bool bandera = true;
            while (temp != null)
            {
                if (producto.codigo == temp.codigo)
                {
                    bandera = false;
                }
                temp = temp.siguiente;
            }
            if (bandera)
            {
                temp = inicio;
                if (pos == 1)
                {
                    producto.siguiente = inicio;
                    inicio = producto;
                }
                else
                {
                    for (int i = 1; i < pos - 1; i++)
                    {
                        temp = temp.siguiente;
                    }
                    producto.siguiente = temp.siguiente;
                    temp.siguiente = producto;
                }
            }
        }
    }
}

