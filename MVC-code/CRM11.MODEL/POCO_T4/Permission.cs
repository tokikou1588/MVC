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
	public partial class Permission
	{
		public Permission ToPOCO(){
			return new Permission(){
								perId=this.perId,
				perParent=this.perParent,
				perName=this.perName,
				perRemark=this.perRemark,
				perAreaName=this.perAreaName,
				perControllerName=this.perControllerName,
				perActionName=this.perActionName,
				perFormMethod=this.perFormMethod,
				perOperationType=this.perOperationType,
				perJsMethodName=this.perJsMethodName,
				perIco=this.perIco,
				perIsLink=this.perIsLink,
				perOrder=this.perOrder,
				perIsShow=this.perIsShow,
				perIsDel=this.perIsDel,
				perAddTime=this.perAddTime,
			};
		}
	}
}
