using System;
namespace cadastro_de_clientes.Interfaces
{
	public interface Imposto
	{
		double CalculaImposto(double Rendimento);
		Imposto Proximo { get; set; }
	}
}

