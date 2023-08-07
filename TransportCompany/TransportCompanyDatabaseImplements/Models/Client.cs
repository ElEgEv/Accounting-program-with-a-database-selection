using System;
using System.Collections.Generic;
using TransportCompanyContracts.BindingModels;
using TransportCompanyContracts.ViewModels;

namespace TransportCompanyDatabaseImplements.Models;

public partial class Client
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Trucking> Truckings { get; set; } = new List<Trucking>();

	public static Client Create(ClientBindingModel model)
	{
		return new Client()
		{
			Id = model.Id,
			Name = model.Name,
			Surname = model.Surname,
			Patronymic = model.Patronymic,
			Telephone = model.Telephone,
			Email = model.Email,
		};
	}

	public void Update(ClientBindingModel model)
	{
		Id = model.Id;
		Name = model.Name;
		Surname = model.Surname;
		Patronymic = model.Patronymic;
		Telephone = model.Telephone;
		Email = model.Email;
	}

	public ClientViewModel GetViewModel => new()
	{
		Id = Id,
		Name = Name,
		Surname = Surname,
		Patronymic = Patronymic,
		Telephone = Telephone,
		Email = Email
	};
}
