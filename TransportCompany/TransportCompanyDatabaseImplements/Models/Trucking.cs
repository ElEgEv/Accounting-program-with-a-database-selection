using System;
using System.Collections.Generic;
using TransportCompanyContracts.BindingModels;
using TransportCompanyContracts.ViewModels;

namespace TransportCompanyDatabaseImplements.Models;

public partial class Trucking
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public int CargoId { get; set; }

    public double Price { get; set; }

    public DateTime DateStart { get; set; }

    public DateTime DateEnd { get; set; }

    public int TransportationId { get; set; }

    public int TransportId { get; set; }

    public virtual Cargo Cargo { get; set; } = null!;

    public virtual Client Client { get; set; } = null!;

    public virtual Transport Transport { get; set; } = null!;

    public virtual TypeTransportation Transportation { get; set; } = null!;

	public static Trucking? Create(TruckingBindingModel model)
	{
		if (model == null)
		{
			return null;
		}

		return new Trucking()
		{
			Id = model.Id,
			ClientId = model.ClientId,
			CargoId = model.CargoId,
			Price = model.Price,
			DateStart = model.DateStart,
			DateEnd = model.DateEnd,
			TransportationId = model.TransportationId,
			TransportId = model.TransportId
		};
	}

	public void Update(TruckingBindingModel model)
	{
		if (model == null)
		{
			return;
		}

		Id = model.Id;
		ClientId = model.ClientId;
		CargoId = model.CargoId;
		Price = model.Price;
		DateStart = model.DateStart;
		DateEnd = model.DateEnd;
		TransportationId = model.TransportationId;
		TransportId = model.TransportId;
	}

	public TruckingViewModel GetViewModel => new()
	{
		Id = Id,
		ClientId = ClientId,
		CargoId = CargoId,
		Price = Price,
		DateStart = DateStart,
		DateEnd = DateEnd,
		TransportationId = TransportationId,
		TransportId = TransportId,
		ClientName =  Client == null ? string.Empty : Client.Name,
		ClientSurname = Client == null ? string.Empty : Client.Surname,
		ClientPatronymic = Client == null ? string.Empty : Client.Patronymic,
		ClientEmail = Client == null ? string.Empty : Client.Email,
		TypeTransportation = Transportation == null ? string.Empty : Transportation.TransportationType,
		TransportName = Transport == null ? string.Empty : Transport.TransportType,
		Cargo = Cargo == null ? string.Empty : Cargo.TypeCargo
	};
}
