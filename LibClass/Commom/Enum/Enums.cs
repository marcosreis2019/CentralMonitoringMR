using System.ComponentModel;

namespace LibClass.Commom.Enum
{
	public enum MonitoredAccount
	{
		[Description("1000 - Conta Desconhecida")]
		Unknown = 1000,

		[Description("2014 - Conta Padrão")]
		Standard = 2014,

		[Description("2138 - Conta do Governo")]
		Government = 2138,

		[Description("2147 - Conta Particular")]
		Private = 2147,

		[Description("2241 - Conta Registrada")]
		Registered = 2241,

		[Description("2493 - Conta Juvenil")]
		Youth = 2493,

		[Description("9999 - Conta Cancelada")]
		Canceled = 9999
	}

	public enum Event
    {
		[Description("1130 - Disparo de Zona")]
		ZoneShooting = 1130,

		[Description("3402 - Partição Armada")]
		ArmedPartition = 3402,

		[Description("1402 - Partição Desarmada")]
		DisarmedPartition = 1402,

		[Description("1144 - Violação de Tamper")]
		TamperViolation = 1144,

		[Description("1110 - Incêndio")]
		Fire = 1110,

		[Description("1121 - Emergência Silenciosa")]
		SilentEmergency = 1121,

		[Description("1100 - Emergência Médica")]
		MedicalEmergency = 1100,

		[Description("1300 - Falha de Fonte Auxiliar")]
		AuxiliaryPowerSupplyFailure = 1300,

		[Description("1301 - Falha de Energia Elétrica")]
		PowerFailure = 1301,

		[Description("1302 - Falha de Bateria")]
		BatteryFailure = 1302,

		[Description("1333 - Falha de Tensão no Barramento")]
		BusVoltageFailure = 1333,

		[Description("1321 - Falha de Sirene")]
		SirenFailure = 1321,

		[Description("1143 - Falha de Módulo Expansor")]
		ExpanderModuleFailure = 1143,

		[Description("1350 - Falha de Comunicação")]
		CommunicationFailure = 1350,

		[Description("1142 - Curto Circuito na Zona")]
		ShortCircuitInZone = 1142,

		[Description("3401 - Alarme Armado")]
		ArmedAlarm = 3401,

		[Description("1401 - Alarme Desarmado")]
		DisarmedAlarm = 1401,

		[Description("3403 - Alarme Auto Armado")]
		AutoArmedAlarm = 3403,

		[Description("3456 - Alarme Armado Forçado")]
		ForcedArmedAlarm = 3456,

		[Description("1570 - Zona Inibida")]
		InhibitedZone = 1570,

		[Description("3130 - Restauro de Zona")]
		ZoneRestore = 3130,
		
		[Description("3144 - Restauro de Tamper")]
		TamperRestoration = 3144,
		
		[Description("3300 - Restauro Fonte Auxiliar")]
		AuxiliarySourceRestoration = 3300,
		
		[Description("3301 - Restauro Energia Elétrica")]
		ElectricPowerRestoration = 3301,
		
		[Description("3302 - Restauro de Bateria")]
		BatteryRestore = 3302,
		
		[Description("3333 - Restauro Tensão no Barramento")]
		BusVoltageRestoration = 3333,
		
		[Description("3321 - Restauro de Sirene")]
		SirenRestoration = 3321,
		
		[Description("3143 - Restauro Módulo Expansor")]
		ExpansionModuleRestoration = 3143,
		
		[Description("3142 - Restauro Curto Circuito")]
		ShortCircuitRestoration = 3142
	}

	public enum Partition
	{
		[Description("1 - Alfa")]
		Alpha = 1,

		[Description("2 - Beta")]
		Beta = 2,

		[Description("3 - Gama")]
		Gamma = 3,

		[Description("4 - Delta")]
		Delta = 4,

		[Description("5 - Épsilon")]
		Epsilon = 5,

		[Description("6 - Zeta")]
		Zeta = 6,

		[Description("7 - Etá")]
		Eta = 7,

		[Description("8 - Teta")]
		Theta = 8,

		[Description("9 - Iota")]
		Iota = 9,

		[Description("10 - Kappa")]
		Kappa = 10
	}

	public enum Zone
	{
		[Description("1 - Zona 01")]
		Zone01 = 1,

		[Description("2 - Zona 02")]
		Zone02 = 2,

		[Description("3 - Zona 03")]
		Zone03 = 3,

		[Description("4 - Zona 04")]
		Zone04 = 4,

		[Description("5 - Zona 05")]
		Zone05 = 5,

		[Description("6 - Zona 06")]
		Zone06 = 6,

		[Description("7 - Zona 07")]
		Zone07 = 7,

		[Description("8 - Zona 08")]
		Zone08 = 8,

		[Description("9 - Zona 09")]
		Zone09 = 9,

		[Description("10 - Zona 10")]
		Zone10 = 10
	}

	public enum User
	{
		[Description("1 - Sistema")]
		System = 1,

		[Description("2 - Marcos Reis")]
		MarcosReis = 2,

		[Description("3 - Fulano")]
		Fulano = 3,

		[Description("4 - Beltrano")]
		Beltrano = 4,

		[Description("5 - Sicrano")]
		Sicrano = 5,

		[Description("6 - Operador")]
		Operator = 6,

		[Description("7 - Técnico")]
		Technician = 7,

		[Description("8 - Engenheiro")]
		Engineer = 8,

		[Description("9 - Arquiteto")]
		Architect = 9,

		[Description("10 - Coordenador")]
		Coordinator = 10
	}
}