//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRM11.MODEL
{
	public partial class Department
	{
		public Department ToPOCO(){
			return new Department(){
								depId=this.depId,
				depName=this.depName,
				depRemark=this.depRemark,
				depIsDel=this.depIsDel,
				depAddTime=this.depAddTime,
			};
		}
	}
}
