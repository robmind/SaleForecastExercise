using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BusinessObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ServiceObjects
{
	public class ProductService
	{

		/// <summary>
		/// Parsing json objects from current string
		/// </summary>
		public List<Product> JsonGrabbingProcess()
		{
			List<Product> _products = new List<Product>();

			try
			{
				string text = System.IO.File.ReadAllText(@"D:\\Project\\WebDeneme\\Totvs\\TOTVSLabSalesProject\\sample.json");

				dynamic coreArray = JsonConvert.DeserializeObject(text);


				foreach (var jsonProduct in coreArray)
				{
					Product product = new Product();

					//[JsonProperty("valorTotal")]
					Complemento complemento = new Complemento {ValorTotal = jsonProduct.complemento["valorTotal"]};

					//[JsonProperty("dets")]
					List<Det> detList = new List<Det>();
					foreach (var detInnerCol in jsonProduct.dets)
					{
						Det det = new Det {NItem = detInnerCol.nItem};

						Prod prod = new Prod
						{
							IndTot = detInnerCol.prod["indTot"],
							QCom = detInnerCol.prod["qCom"],
							UCom = detInnerCol.prod["uCom"],
							VProd = detInnerCol.prod["vProd"],
							VUnCom = detInnerCol.prod["vUnCom"],
							XProd = detInnerCol.prod["xProd"]
						};

						det.Prod = prod;

						detList.Add(det);
					}

					//[JsonProperty("emit")]
					Emit emit = new Emit
					{
						Cnpj = jsonProduct.emit["cnpj"],
						XFant = jsonProduct.emit["xFant"]
					};

					//[JsonProperty("enderEmit")]
					EnderEmit enderEmit = new EnderEmit()
					{
						Fone = jsonProduct.emit["enderEmit"]["fone"],
						XBairro = jsonProduct.emit["enderEmit"]["xBairro"],
						XLgr = jsonProduct.emit["enderEmit"]["xLgr"],
						XMun = jsonProduct.emit["enderEmit"]["xMun"],
						XPais = jsonProduct.emit["enderEmit"]["xPais"],
						Uf = jsonProduct.emit["enderEmit"]["uf"]
					};
					emit.EnderEmit = enderEmit;

					//[JsonProperty("ide")]
					Ide ide = new Ide
					{
						NatOp = jsonProduct.ide["natOp"]
					};

					//[JsonProperty("dhEmi")]
					DhEmi dhEmi = new DhEmi
					{
						Date = jsonProduct.ide["dhEmi"]["$date"]
					};
					ide.DhEmi = dhEmi;

					//[JsonProperty("infAdic")]
					InfAdic infAdic = new InfAdic
					{
						InfCpl = jsonProduct.infAdic["infCpl"]
					};

					//[JsonProperty("icmsTot")]
					IcmsTot icmsTot = new IcmsTot
					{
						VDesc = jsonProduct.total["icmsTot"]["vDesc"],
						VFrete = jsonProduct.total["icmsTot"]["vFrete"],
						VOutro = jsonProduct.total["icmsTot"]["vOutro"],
						VProd = jsonProduct.total["icmsTot"]["vProd"],
						VSeg = jsonProduct.total["icmsTot"]["vSeg"],
						VTotTrib = jsonProduct.total["icmsTot"]["vTotTrib"],
						Vbc = jsonProduct.total["icmsTot"]["vbc"],
						Vbcst = jsonProduct.total["icmsTot"]["vbcst"],
						Vcofins = jsonProduct.total["icmsTot"]["vcofins"],
						Vicms = jsonProduct.total["icmsTot"]["vicms"],
						VicmsDeson = jsonProduct.total["icmsTot"]["vicmsDeson"],
						Vii = jsonProduct.total["icmsTot"]["vii"],
						Vipi = jsonProduct.total["icmsTot"]["vipi"],
						Vnf = jsonProduct.total["icmsTot"]["vnf"],
						Vpis = jsonProduct.total["icmsTot"]["vpis"],
						Vst = jsonProduct.total["icmsTot"]["vst"]
					};

					//[JsonProperty("total")]
					Total total = new Total
					{
						IcmsTot = icmsTot
					};

					//[JsonProperty("complemento")]
					product.VersaoDocumento = jsonProduct.versaoDocumento;

					product.Complemento = complemento;
					product.Dets = detList;
					product.Emit = emit;
					product.Ide = ide;
					product.InfAdic = infAdic;
					product.Total = total;
					_products.Add(product);
				}
			}
			catch (DirectoryNotFoundException)
			{
				Console.WriteLine("Directory not found");
			}
			catch (IOException)
			{
				Console.WriteLine("File read error - ioexception");
			}
			catch (OutOfMemoryException)
			{
				Console.WriteLine("File read error - memoryexception");
			}

			return _products;
		}
	}
}
