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
	public partial class WorkFlowApplyDetail
	{
		public WorkFlowApplyDetail ToPOCO(){
			return new WorkFlowApplyDetail(){
								wfadId=this.wfadId,
				wfadApplyId=this.wfadApplyId,
				wfadCurNodeId=this.wfadCurNodeId,
				wfadUserId=this.wfadUserId,
				wfadContent=this.wfadContent,
				wfadOperation=this.wfadOperation,
				wfadAddTime=this.wfadAddTime,
				wfadIsDel=this.wfadIsDel,
			};
		}
	}
}