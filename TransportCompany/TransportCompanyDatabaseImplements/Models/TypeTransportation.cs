using System;
using System.Collections.Generic;
using TransportCompanyContracts.BindingModels;
using TransportCompanyContracts.ViewModels;

namespace TransportCompanyDatabaseImplements.Models;

public partial class TypeTransportation
{
    public int Id { get; set; }

    public string TransportationType { get; set; } = null!;

    public virtual ICollection<Trucking> Truckings { get; set; } = new List<Trucking>();

	public static TypeTransportation Create(TransportationBindingModel model)
	{
		return new TypeTransportation()
		{
			Id = model.Id,
			TransportationType = model.TransportationType
		};
	}

	public void Update(TransportationBindingModel model)
	{
		Id = model.Id;
		TransportationType = model.TransportationType;
	}

	public TransportationViewModel GetViewModel => new()
	{
		Id = Id,
		TransportationType = TransportationType
	};
}
