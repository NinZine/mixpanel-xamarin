using System;

namespace MixpanelBindings
{
	public enum MPWebSocketState : uint {
		Connecting = 0,
		Open = 1,
		Closing = 2,
		Closed = 3
	}
}

