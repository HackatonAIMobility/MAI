using ObjCRuntime;
﻿using UIKit;
﻿
﻿namespace MAI;
﻿
﻿/// <summary>
﻿/// Entry point for the Mac Catalyst application.
﻿/// This class is responsible for bootstrapping the application on macOS using Mac Catalyst.
﻿/// </summary>
﻿public class Program
﻿{
﻿	/// <summary>
﻿	/// The main entry point of the application for Mac Catalyst.
﻿	/// </summary>
﻿	/// <param name="args">Command-line arguments passed to the application.</param>
﻿	static void Main(string[] args)
﻿	{
﻿		// if you want to use a different Application Delegate class from "AppDelegate"
﻿		// you can specify it here.
﻿		UIApplication.Main(args, null, typeof(AppDelegate));
﻿	}
﻿}
﻿