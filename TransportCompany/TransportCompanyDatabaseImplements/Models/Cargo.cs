using System;
using System.Collections.Generic;
using TransportCompanyContracts.BindingModels;
using TransportCompanyContracts.ViewModels;

namespace TransportCompanyDatabaseImplements.Models;

public partial class Cargo
{
    public int Id { get; set; }

    public string TypeCargo { get; set; } = null!;

    public virtual ICollection<Trucking> Truckings { get; set; } = new List<Trucking>();

	public static Cargo Create(CargoBindingModel model)
	{
		return new Cargo()
		{
			Id = model.Id,
			TypeCargo = model.TypeCargo
		};
	}

	public void Update(CargoBindingModel model)
	{
		TypeCargo = model.TypeCargo;
	}

	public CargoViewModel GetViewModel => new()
	{
		Id = Id,
		TypeCargo = TypeCargo
	};
}
