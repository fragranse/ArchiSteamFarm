﻿/*
    _                _      _  ____   _                           _____
   / \    _ __  ___ | |__  (_)/ ___| | |_  ___   __ _  _ __ ___  |  ___|__ _  _ __  _ __ ___
  / _ \  | '__|/ __|| '_ \ | |\___ \ | __|/ _ \ / _` || '_ ` _ \ | |_  / _` || '__|| '_ ` _ \
 / ___ \ | |  | (__ | | | || | ___) || |_|  __/| (_| || | | | | ||  _|| (_| || |   | | | | | |
/_/   \_\|_|   \___||_| |_||_||____/  \__|\___| \__,_||_| |_| |_||_|   \__,_||_|   |_| |_| |_|

 Copyright 2015-2017 Łukasz "JustArchi" Domeradzki
 Contact: JustArchi@JustArchi.net

 Licensed under the Apache License, Version 2.0 (the "License");
 you may not use this file except in compliance with the License.
 You may obtain a copy of the License at

 http://www.apache.org/licenses/LICENSE-2.0
					
 Unless required by applicable law or agreed to in writing, software
 distributed under the License is distributed on an "AS IS" BASIS,
 WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 See the License for the specific language governing permissions and
 limitations under the License.

*/

using SteamKit2;

namespace ArchiSteamFarm {
	internal static class Events {
		internal static void OnBotShutdown() { }

		internal static void OnPersonaState(Bot bot, SteamFriends.PersonaStateCallback callback) {
			if (bot == null) {
				Program.ArchiLogger.LogNullError(nameof(bot));
				return;
			}

			if (callback == null) {
				bot.ArchiLogger.LogNullError(nameof(callback));
				return;
			}

			BotStatusForm form;
			if (!BotStatusForm.BotForms.TryGetValue(bot.BotName, out form)) {
				return;
			}

			form.OnStateUpdated(callback);
		}
	}
}