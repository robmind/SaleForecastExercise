using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BusinessObjects
{

	public class Complemento
	{

		[JsonProperty("valorTotal")]
		public double ValorTotal { get; set; }
	}

	public class Prod
	{

		[JsonProperty("indTot")]
		public string IndTot { get; set; }

		[JsonProperty("qCom")]
		public double QCom { get; set; }

		[JsonProperty("uCom")]
		public string UCom { get; set; }

		[JsonProperty("vProd")]
		public double VProd { get; set; }

		[JsonProperty("vUnCom")]
		public double VUnCom { get; set; }

		[JsonProperty("xProd")]
		public string XProd { get; set; }
	}

	public class Det
	{

		[JsonProperty("nItem")]
		public string NItem { get; set; }

		[JsonProperty("prod")]
		public Prod Prod { get; set; }
	}

	public class EnderEmit
	{

		[JsonProperty("fone")]
		public string Fone { get; set; }

		[JsonProperty("xBairro")]
		public string XBairro { get; set; }

		[JsonProperty("xLgr")]
		public string XLgr { get; set; }

		[JsonProperty("xMun")]
		public string XMun { get; set; }

		[JsonProperty("xPais")]
		public string XPais { get; set; }

		[JsonProperty("uf")]
		public string Uf { get; set; }
	}

	public class Emit
	{

		[JsonProperty("cnpj")]
		public string Cnpj { get; set; }

		[JsonProperty("enderEmit")]
		public EnderEmit EnderEmit { get; set; }

		[JsonProperty("xFant")]
		public string XFant { get; set; }
	}

	public class DhEmi
	{

		[JsonProperty("$date")]
		public DateTime Date { get; set; }
	}

	public class Ide
	{

		[JsonProperty("dhEmi")]
		public DhEmi DhEmi { get; set; }

		[JsonProperty("natOp")]
		public string NatOp { get; set; }
	}

	public class InfAdic
	{

		[JsonProperty("infCpl")]
		public string InfCpl { get; set; }
	}

	public class IcmsTot
	{

		[JsonProperty("vDesc")]
		public int VDesc { get; set; }

		[JsonProperty("vFrete")]
		public int VFrete { get; set; }

		[JsonProperty("vOutro")]
		public int VOutro { get; set; }

		[JsonProperty("vProd")]
		public double VProd { get; set; }

		[JsonProperty("vSeg")]
		public int VSeg { get; set; }

		[JsonProperty("vTotTrib")]
		public double VTotTrib { get; set; }

		[JsonProperty("vbc")]
		public int Vbc { get; set; }

		[JsonProperty("vbcst")]
		public int Vbcst { get; set; }

		[JsonProperty("vcofins")]
		public int Vcofins { get; set; }

		[JsonProperty("vicms")]
		public int Vicms { get; set; }

		[JsonProperty("vicmsDeson")]
		public int VicmsDeson { get; set; }

		[JsonProperty("vii")]
		public int Vii { get; set; }

		[JsonProperty("vipi")]
		public int Vipi { get; set; }

		[JsonProperty("vnf")]
		public double Vnf { get; set; }

		[JsonProperty("vpis")]
		public int Vpis { get; set; }

		[JsonProperty("vst")]
		public int Vst { get; set; }
	}

	public class Total
	{

		[JsonProperty("icmsTot")]
		public IcmsTot IcmsTot { get; set; }
	}

	public class Product
	{

		[JsonProperty("complemento")]
		public Complemento Complemento { get; set; }

		[JsonProperty("dets")]
		public List<Det> Dets { get; set; }

		[JsonProperty("emit")]
		public Emit Emit { get; set; }

		[JsonProperty("ide")]
		public Ide Ide { get; set; }

		[JsonProperty("infAdic")]
		public InfAdic InfAdic { get; set; }

		[JsonProperty("total")]
		public Total Total { get; set; }

		[JsonProperty("versaoDocumento")]
		public object VersaoDocumento { get; set; }
	}

}
