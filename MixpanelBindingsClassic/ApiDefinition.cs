using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MixpanelBindingsClassic
{
	// The first step to creating a binding is to add your native library ("libNativeLibrary.a")
	// to the project by right-clicking (or Control-clicking) the folder containing this source
	// file and clicking "Add files..." and then simply select the native library (or libraries)
	// that you want to bind.
	//
	// When you do that, you'll notice that MonoDevelop generates a code-behind file for each
	// native library which will contain a [LinkWith] attribute. MonoDevelop auto-detects the
	// architectures that the native library supports and fills in that information for you,
	// however, it cannot auto-detect any Frameworks or other system libraries that the
	// native library may depend on, so you'll need to fill in that information yourself.
	//
	// Once you've done that, you're ready to move on to binding the API...
	//
	//
	// Here is where you'd define your API definition for the native Objective-C library.
	//
	// For example, to bind the following Objective-C class:
	//
	//     @interface Widget : NSObject {
	//     }
	//
	// The C# binding would look like this:
	//
	//     [BaseType (typeof (NSObject))]
	//     interface Widget {
	//     }
	//
	// To bind Objective-C properties, such as:
	//
	//     @property (nonatomic, readwrite, assign) CGPoint center;
	//
	// You would add a property definition in the C# interface like so:
	//
	//     [Export ("center")]
	//     PointF Center { get; set; }
	//
	// To bind an Objective-C method, such as:
	//
	//     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
	//
	// You would add a method definition to the C# interface like so:
	//
	//     [Export ("doSomething:atIndex:")]
	//     void DoSomething (NSObject object, int index);
	//
	// Objective-C "constructors" such as:
	//
	//     -(id)initWithElmo:(ElmoMuppet *)elmo;
	//
	// Can be bound as:
	//
	//     [Export ("initWithElmo:")]
	//     IntPtr Constructor (ElmoMuppet elmo);
	//
	// For more information, see http://docs.xamarin.com/ios/advanced_topics/binding_objective-c_libraries
	//

	// @interface Mixpanel : NSObject
	[BaseType (typeof (NSObject))]
	interface Mixpanel {

		// -(instancetype)initWithToken:(NSString *)apiToken launchOptions:(NSDictionary *)launchOptions andFlushInterval:(NSUInteger)flushInterval;
		[Export ("initWithToken:launchOptions:andFlushInterval:")]
		IntPtr Constructor (string apiToken, NSDictionary launchOptions, uint flushInterval);

		// -(instancetype)initWithToken:(NSString *)apiToken andFlushInterval:(NSUInteger)flushInterval;
		[Export ("initWithToken:andFlushInterval:")]
		IntPtr Constructor (string apiToken, uint flushInterval);

		// @property (readonly, atomic, strong) MixpanelPeople * people;
		[Export ("people", ArgumentSemantic.Retain)]
		MixpanelPeople People { get; }

		// @property (readonly, copy, atomic) NSString * distinctId;
		[Export ("distinctId")]
		string DistinctId { get; }

		// @property (copy, atomic) NSString * nameTag;
		[Export ("nameTag")]
		string NameTag { get; set; }

		// @property (copy, atomic) NSString * serverURL;
		[Export ("serverURL")]
		string ServerURL { get; set; }

		// @property (atomic) NSUInteger flushInterval;
		[Export ("flushInterval")]
		uint FlushInterval { get; set; }

		// @property (atomic) BOOL flushOnBackground;
		[Export ("flushOnBackground")]
		bool FlushOnBackground { get; set; }

		// @property (atomic) BOOL showNetworkActivityIndicator;
		[Export ("showNetworkActivityIndicator")]
		bool ShowNetworkActivityIndicator { get; set; }

		// @property (atomic) BOOL checkForSurveysOnActive;
		[Export ("checkForSurveysOnActive")]
		bool CheckForSurveysOnActive { get; set; }

		// @property (atomic) BOOL showSurveyOnActive;
		[Export ("showSurveyOnActive")]
		bool ShowSurveyOnActive { get; set; }

		// @property (atomic) BOOL checkForNotificationsOnActive;
		[Export ("checkForNotificationsOnActive")]
		bool CheckForNotificationsOnActive { get; set; }

		// @property (atomic) BOOL checkForVariantsOnActive;
		[Export ("checkForVariantsOnActive")]
		bool CheckForVariantsOnActive { get; set; }

		// @property (atomic) BOOL showNotificationOnActive;
		[Export ("showNotificationOnActive")]
		bool ShowNotificationOnActive { get; set; }

		// @property (atomic) CGFloat miniNotificationPresentationTime;
		[Export ("miniNotificationPresentationTime")]
		float MiniNotificationPresentationTime { get; set; }

		// @property (atomic, weak) id<MixpanelDelegate> delegate;
		[Export ("delegate", ArgumentSemantic.Weak)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		// @property (atomic, weak) id<MixpanelDelegate> delegate;
		[Wrap ("WeakDelegate")]
		MixpanelDelegate Delegate { get; set; }

		// +(Mixpanel *)sharedInstanceWithToken:(NSString *)apiToken;
		[Static, Export ("sharedInstanceWithToken:")]
		Mixpanel SharedInstanceWithToken (string apiToken);

		// +(Mixpanel *)sharedInstanceWithToken:(NSString *)apiToken launchOptions:(NSDictionary *)launchOptions;
		[Static, Export ("sharedInstanceWithToken:launchOptions:")]
		Mixpanel SharedInstanceWithToken (string apiToken, NSDictionary launchOptions);

		// +(Mixpanel *)sharedInstance;
		[Static, Export ("sharedInstance")]
		Mixpanel SharedInstance ();

		// -(void)identify:(NSString *)distinctId;
		[Export ("identify:")]
		void Identify (string distinctId);

		// -(void)track:(NSString *)event;
		[Export ("track:")]
		void Track (string e);

		// -(void)track:(NSString *)event properties:(NSDictionary *)properties;
		[Export ("track:properties:")]
		void Track (string e, NSDictionary properties);

		// -(void)trackPushNotification:(NSDictionary *)userInfo;
		[Export ("trackPushNotification:")]
		void TrackPushNotification (NSDictionary userInfo);

		// -(void)registerSuperProperties:(NSDictionary *)properties;
		[Export ("registerSuperProperties:")]
		void RegisterSuperProperties (NSDictionary properties);

		// -(void)registerSuperPropertiesOnce:(NSDictionary *)properties;
		[Export ("registerSuperPropertiesOnce:")]
		void RegisterSuperPropertiesOnce (NSDictionary properties);

		// -(void)registerSuperPropertiesOnce:(NSDictionary *)properties defaultValue:(id)defaultValue;
		[Export ("registerSuperPropertiesOnce:defaultValue:")]
		void RegisterSuperPropertiesOnce (NSDictionary properties, NSObject defaultValue);

		// -(void)unregisterSuperProperty:(NSString *)propertyName;
		[Export ("unregisterSuperProperty:")]
		void UnregisterSuperProperty (string propertyName);

		// -(void)clearSuperProperties;
		[Export ("clearSuperProperties")]
		void ClearSuperProperties ();

		// -(NSDictionary *)currentSuperProperties;
		[Export ("currentSuperProperties")]
		NSDictionary CurrentSuperProperties ();

		// -(void)timeEvent:(NSString *)event;
		[Export ("timeEvent:")]
		void TimeEvent (string e);

		// -(void)clearTimedEvents;
		[Export ("clearTimedEvents")]
		void ClearTimedEvents ();

		// -(void)reset;
		[Export ("reset")]
		void Reset ();

		// -(void)flush;
		[Export ("flush")]
		void Flush ();

		// -(void)archive;
		[Export ("archive")]
		void Archive ();

		// -(void)showSurveyWithID:(NSUInteger)ID;
		[Export ("showSurveyWithID:")]
		void ShowSurveyWithID (uint ID);

		// -(void)showSurvey;
		[Export ("showSurvey")]
		void ShowSurvey ();

		// -(void)showNotificationWithID:(NSUInteger)ID;
		[Export ("showNotificationWithID:")]
		void ShowNotificationWithID (uint ID);

		// -(void)showNotificationWithType:(NSString *)type;
		[Export ("showNotificationWithType:")]
		void ShowNotificationWithType (string type);

		// -(void)showNotification;
		[Export ("showNotification")]
		void ShowNotification ();

		// -(void)joinExperiments;
		[Export ("joinExperiments")]
		void JoinExperiments ();

		// -(void)createAlias:(NSString *)alias forDistinctID:(NSString *)distinctID;
		[Export ("createAlias:forDistinctID:")]
		void CreateAlias (string alias, string distinctID);

		// -(NSString *)libVersion;
		[Export ("libVersion")]
		string LibVersion ();
	}

	// @interface MixpanelPeople : NSObject
	[BaseType (typeof (NSObject))]
	interface MixpanelPeople {

		// -(void)addPushDeviceToken:(NSData *)deviceToken;
		[Export ("addPushDeviceToken:")]
		void AddPushDeviceToken (NSData deviceToken);

		// -(void)set:(NSDictionary *)properties;
		[Export ("set:")]
		void Set (NSDictionary properties);

		// -(void)set:(NSString *)property to:(id)object;
		[Export ("set:to:")]
		void Set (string property, NSObject o);

		// -(void)setOnce:(NSDictionary *)properties;
		[Export ("setOnce:")]
		void SetOnce (NSDictionary properties);

		// -(void)increment:(NSDictionary *)properties;
		[Export ("increment:")]
		void Increment (NSDictionary properties);

		// -(void)increment:(NSString *)property by:(NSNumber *)amount;
		[Export ("increment:by:")]
		void Increment (string property, NSNumber amount);

		// -(void)append:(NSDictionary *)properties;
		[Export ("append:")]
		void Append (NSDictionary properties);

		// -(void)union:(NSDictionary *)properties;
		[Export ("union:")]
		void Union (NSDictionary properties);

		// -(void)trackCharge:(NSNumber *)amount;
		[Export ("trackCharge:")]
		void TrackCharge (NSNumber amount);

		// -(void)trackCharge:(NSNumber *)amount withProperties:(NSDictionary *)properties;
		[Export ("trackCharge:withProperties:")]
		void TrackCharge (NSNumber amount, NSDictionary properties);

		// -(void)clearCharges;
		[Export ("clearCharges")]
		void ClearCharges ();

		// -(void)deleteUser;
		[Export ("deleteUser")]
		void DeleteUser ();
	}

	// @protocol MixpanelDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface MixpanelDelegate {

		// @optional -(BOOL)mixpanelWillFlush:(Mixpanel *)mixpanel;
		[Export ("mixpanelWillFlush:")]
		bool MixpanelWillFlush (Mixpanel mixpanel);
	}

}

