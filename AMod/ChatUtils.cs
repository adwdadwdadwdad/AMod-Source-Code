using System;
using Il2Cpp;
using Il2CppSystem;

namespace AMod
{
	// Token: 0x0200004F RID: 79
	internal class ChatUtils
	{
		// Token: 0x0600024B RID: 587 RVA: 0x0000A2E8 File Offset: 0x000084E8
		public static void Error(string message)
		{
			ChatMessage msg = new ChatMessage(message + "</color>", Il2CppSystem.DateTime.Now, ChatMessage.ChannelTypes.SERVER_MESSAGE, "<B><#ff2919>[<#f25449>ERROR<#ff2919>]</color></color></color></B>", "", "");
			ControllerHelper.chatUI.NewMessage(msg);
		}

		// Token: 0x0600024C RID: 588 RVA: 0x0000A328 File Offset: 0x00008528
		public static void D(string message)
		{
			ChatMessage msg = new ChatMessage(message + "</color>", Il2CppSystem.DateTime.Now, ChatMessage.ChannelTypes.SERVER_MESSAGE, "<B><#707070>[<#808080>DEBUG<#707070>]</color></color></color></B>", "", "");
			ControllerHelper.chatUI.NewMessage(msg);
		}

		// Token: 0x0600024D RID: 589 RVA: 0x0000A368 File Offset: 0x00008568
		public static void Msg(string message)
		{
			ChatMessage msg = new ChatMessage(message + "</color>", Il2CppSystem.DateTime.Now, ChatMessage.ChannelTypes.SERVER_MESSAGE, "<B><#707070>[<#808080>AMOD<#707070>]</color></color></color></B>", "", "");
			ControllerHelper.chatUI.NewMessage(msg);
		}
	}
}
