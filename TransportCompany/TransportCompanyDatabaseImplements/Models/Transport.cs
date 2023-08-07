using System;
using System.Collections.Generic;
using TransportCompanyContracts.BindingModels;
using TransportCompanyContracts.ViewModels;

namespace TransportCompanyDatabaseImplements.Models;

public partial class Transport
{
    public int Id { get; set; }

    public string TransportType { get; set; } = null!;

    public virtual ICollection<Trucking> Truckings { get; set; } = new List<Trucking>();

	public static Transport Create(TransportBindingModel model)
	{
		return new Transport()
		{
			Id = model.Id,
			TransportType = model.Tranport
		};
	}

	public void Update(TransportBindingModel model)
	{
		Id = model.Id;
		TransportType = model.Tranport;
	}

	public TransportViewModel GetViewModel => new()
	{
		Id = Id,
		Tranport = TransportType
	};
}
