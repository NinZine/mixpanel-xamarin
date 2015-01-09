using System;
using System.Drawing;
using ObjCRuntime;
using Foundation;
using UIKit;

namespace MixpanelBindings
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
	//     CGPoint Center { get; set; }
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


	/*
	// @protocol MPABTestDesignerMessage <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface MPABTestDesignerMessage {

		// @property (readonly, copy, nonatomic) NSString * type;
		[Export ("type")]
		string Type { get; }

		// @required -(void)setPayloadObject:(id)object forKey:(NSString *)key;
		[Export ("setPayloadObject:forKey:")]
		[Abstract]
		void SetPayloadObject (NSObject obj, string key);

		// @required -(id)payloadObjectForKey:(NSString *)key;
		[Export ("payloadObjectForKey:")]
		[Abstract]
		NSObject PayloadObjectForKey (string key);

		// @required -(NSData *)JSONData;
		[Export ("JSONData")]
		[Abstract]
		NSData JSONData ();

		// @required -(NSOperation *)responseCommandWithConnection:(MPABTestDesignerConnection *)connection;
		[Export ("responseCommandWithConnection:")]
		[Abstract]
		NSOperation ResponseCommandWithConnection (MPABTestDesignerConnection connection);
	}

	// @interface MPAbstractABTestDesignerMessage : NSObject <MPABTestDesignerMessage>
	[BaseType (typeof (NSObject))]
	interface MPAbstractABTestDesignerMessage : MPABTestDesignerMessage {

		// -(id)initWithType:(NSString *)type;
		[Export ("initWithType:")]
		IntPtr Constructor (string type);

		// -(id)initWithType:(NSString *)type payload:(NSDictionary *)payload;
		[Export ("initWithType:payload:")]
		IntPtr Constructor (string type, NSDictionary payload);

		// @property (readonly, copy, nonatomic) NSString * type;
		[Export ("type")]
		string Type { get; }

		// +(instancetype)messageWithType:(NSString *)type payload:(NSDictionary *)payload;
		[Static, Export ("messageWithType:payload:")]
		MPAbstractABTestDesignerMessage MessageWithType (string type, NSDictionary payload);

		// -(void)setPayloadObject:(id)object forKey:(NSString *)key;
		[Export ("setPayloadObject:forKey:")]
		void SetPayloadObject (NSObject obj, string key);

		// -(id)payloadObjectForKey:(NSString *)key;
		[Export ("payloadObjectForKey:")]
		NSObject PayloadObjectForKey (string key);

		// -(NSDictionary *)payload;
		[Export ("payload")]
		NSDictionary Payload ();

		// -(NSData *)JSONData;
		[Export ("JSONData")]
		NSData JSONData ();
	}

	// @interface MPABTestDesignerChangeRequestMessage : MPAbstractABTestDesignerMessage
	[BaseType (typeof (MPAbstractABTestDesignerMessage))]
	interface MPABTestDesignerChangeRequestMessage {

	}

	// @interface MPABTestDesignerChangeResponseMessage : MPAbstractABTestDesignerMessage
	[BaseType (typeof (MPAbstractABTestDesignerMessage))]
	interface MPABTestDesignerChangeResponseMessage {

		// @property (copy, nonatomic) NSString * status;
		[Export ("status")]
		string Status { get; set; }

		// +(instancetype)message;
		[Static, Export ("message")]
		MPABTestDesignerChangeResponseMessage Message ();
	}

	// @interface MPABTestDesignerClearRequestMessage : MPAbstractABTestDesignerMessage
	[BaseType (typeof (MPAbstractABTestDesignerMessage))]
	interface MPABTestDesignerClearRequestMessage {

	}

	// @interface MPABTestDesignerClearResponseMessage : MPAbstractABTestDesignerMessage
	[BaseType (typeof (MPAbstractABTestDesignerMessage))]
	interface MPABTestDesignerClearResponseMessage {

		// @property (copy, nonatomic) NSString * status;
		[Export ("status")]
		string Status { get; set; }

		// +(instancetype)message;
		[Static, Export ("message")]
		MPABTestDesignerClearResponseMessage Message ();
	}

	// @interface MPWebSocket : NSObject <NSStreamDelegate>
	[BaseType (typeof (NSObject))]
	interface MPWebSocket : NSStreamDelegate {

		// -(id)initWithURLRequest:(NSURLRequest *)request protocols:(NSArray *)protocols;
		[Export ("initWithURLRequest:protocols:")]
		IntPtr Constructor (NSUrlRequest request, NSObject [] protocols);

		// -(id)initWithURLRequest:(NSURLRequest *)request;
		[Export ("initWithURLRequest:")]
		IntPtr Constructor (NSUrlRequest request);

		// -(id)initWithURL:(NSURL *)url protocols:(NSArray *)protocols;
		[Export ("initWithURL:protocols:")]
		IntPtr Constructor (NSUrl url, NSObject [] protocols);

		// -(id)initWithURL:(NSURL *)url;
		[Export ("initWithURL:")]
		IntPtr Constructor (NSUrl url);

		// @property (assign, nonatomic) id<MPWebSocketDelegate> delegate;
		[Export ("delegate", ArgumentSemantic.UnsafeUnretained)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		// @property (assign, nonatomic) id<MPWebSocketDelegate> delegate;
		[Wrap ("WeakDelegate")]
		MPWebSocketDelegate Delegate { get; set; }

		// @property (readonly, nonatomic) MPWebSocketReadyState readyState;
		[Export ("readyState")]
		MPWebSocketState ReadyState { get; }

		// @property (readonly, retain, nonatomic) NSURL * url;
		[Export ("url", ArgumentSemantic.Retain)]
		NSUrl Url { get; }

		// @property (readonly, copy, nonatomic) NSString * protocol;
		[Export ("protocol")]
		string Protocol { get; }

		// -(void)setDelegateOperationQueue:(NSOperationQueue *)queue;
		[Export ("setDelegateOperationQueue:")]
		void SetDelegateOperationQueue (NSOperationQueue queue);

		// -(void)setDelegateDispatchQueue:(dispatch_queue_t)queue;
		[Export ("setDelegateDispatchQueue:")]
		void SetDelegateDispatchQueue (DispatchQueue queue);

		// -(void)scheduleInRunLoop:(NSRunLoop *)aRunLoop forMode:(NSString *)mode;
		[Export ("scheduleInRunLoop:forMode:")]
		void ScheduleInRunLoop (NSRunLoop aRunLoop, string mode);

		// -(void)unscheduleFromRunLoop:(NSRunLoop *)aRunLoop forMode:(NSString *)mode;
		[Export ("unscheduleFromRunLoop:forMode:")]
		void UnscheduleFromRunLoop (NSRunLoop aRunLoop, string mode);

		// -(void)open;
		[Export ("open")]
		void Open ();

		// -(void)close;
		[Export ("close")]
		void Close ();

		// -(void)closeWithCode:(NSInteger)code reason:(NSString *)reason;
		[Export ("closeWithCode:reason:")]
		void CloseWithCode (nint code, string reason);

		// -(void)send:(id)data;
		[Export ("send:")]
		void Send (NSObject data);
	}

	// @protocol MPWebSocketDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface MPWebSocketDelegate {

		// @required -(void)webSocket:(MPWebSocket *)webSocket didReceiveMessage:(id)message;
		[Export ("webSocket:didReceiveMessage:")]
		[Abstract]
		void DidReceiveMessage (MPWebSocket webSocket, NSObject message);

		// @optional -(void)webSocketDidOpen:(MPWebSocket *)webSocket;
		[Export ("webSocketDidOpen:")]
		void WebSocketDidOpen (MPWebSocket webSocket);

		// @optional -(void)webSocket:(MPWebSocket *)webSocket didFailWithError:(NSError *)error;
		[Export ("webSocket:didFailWithError:")]
		void DidFailWithError (MPWebSocket webSocket, NSError error);

		// @optional -(void)webSocket:(MPWebSocket *)webSocket didCloseWithCode:(NSInteger)code reason:(NSString *)reason wasClean:(BOOL)wasClean;
		[Export ("webSocket:didCloseWithCode:reason:wasClean:")]
		void DidCloseWithCode (MPWebSocket webSocket, nint code, string reason, bool wasClean);
	}

	// @interface CertificateAdditions (NSMutableURLRequest)
	[Category]
	[BaseType (typeof (NSMutableURLRequest))]
	interface CertificateAdditions {

		// @property (retain, nonatomic) NSArray * mp_SSLPinnedCertificates;
		[Export ("mp_SSLPinnedCertificates", ArgumentSemantic.Retain)]
		NSObject [] Mp_SSLPinnedCertificates { get; set; }
	}

	// @interface MPABTestDesignerConnection : NSObject
	[BaseType (typeof (NSObject))]
	interface MPABTestDesignerConnection {

		// -(id)initWithURL:(NSURL *)url;
		[Export ("initWithURL:")]
		IntPtr Constructor (NSUrl url);

		// -(id)initWithURL:(NSURL *)url connectCallback:(void (^)())connectCallback disconnectCallback:(void (^)())disconnectCallback;
		[Export ("initWithURL:connectCallback:disconnectCallback:")]
		IntPtr Constructor (NSUrl url, Action connectCallback, Action disconnectCallback);

		// @property (readonly, nonatomic) BOOL connected;
		[Export ("connected")]
		bool Connected { get; }

		// @property (assign, nonatomic) BOOL sessionEnded;
		[Export ("sessionEnded", ArgumentSemantic.UnsafeUnretained)]
		bool SessionEnded { get; set; }

		// -(void)setSessionObject:(id)object forKey:(NSString *)key;
		[Export ("setSessionObject:forKey:")]
		void SetSessionObject (NSObject obj, string key);

		// -(id)sessionObjectForKey:(NSString *)key;
		[Export ("sessionObjectForKey:")]
		NSObject SessionObjectForKey (string key);

		// -(void)sendMessage:(id<MPABTestDesignerMessage>)message;
		[Export ("sendMessage:")]
		void SendMessage (MPABTestDesignerMessage message);

		// -(void)close;
		[Export ("close")]
		void Close ();
	}

	// @interface MPABTestDesignerDeviceInfoRequestMessage : MPAbstractABTestDesignerMessage
	[BaseType (typeof (MPAbstractABTestDesignerMessage))]
	interface MPABTestDesignerDeviceInfoRequestMessage {

	}

	// @interface MPABTestDesignerDeviceInfoResponseMessage : MPAbstractABTestDesignerMessage
	[BaseType (typeof (MPAbstractABTestDesignerMessage))]
	interface MPABTestDesignerDeviceInfoResponseMessage {

		// @property (copy, nonatomic) NSString * systemName;
		[Export ("systemName")]
		string SystemName { get; set; }

		// @property (copy, nonatomic) NSString * systemVersion;
		[Export ("systemVersion")]
		string SystemVersion { get; set; }

		// @property (copy, nonatomic) NSString * appVersion;
		[Export ("appVersion")]
		string AppVersion { get; set; }

		// @property (copy, nonatomic) NSString * appRelease;
		[Export ("appRelease")]
		string AppRelease { get; set; }

		// @property (copy, nonatomic) NSString * deviceName;
		[Export ("deviceName")]
		string DeviceName { get; set; }

		// @property (copy, nonatomic) NSString * deviceModel;
		[Export ("deviceModel")]
		string DeviceModel { get; set; }

		// @property (copy, nonatomic) NSString * libVersion;
		[Export ("libVersion")]
		string LibVersion { get; set; }

		// @property (copy, nonatomic) NSArray * availableFontFamilies;
		[Export ("availableFontFamilies", ArgumentSemantic.Copy)]
		NSObject [] AvailableFontFamilies { get; set; }

		// @property (copy, nonatomic) NSString * mainBundleIdentifier;
		[Export ("mainBundleIdentifier")]
		string MainBundleIdentifier { get; set; }

		// @property (copy, nonatomic) NSArray * tweaks;
		[Export ("tweaks", ArgumentSemantic.Copy)]
		NSObject [] Tweaks { get; set; }

		// +(instancetype)message;
		[Static, Export ("message")]
		MPABTestDesignerDeviceInfoResponseMessage Message ();
	}

	// @interface MPABTestDesignerDisconnectMessage : MPAbstractABTestDesignerMessage
	[BaseType (typeof (MPAbstractABTestDesignerMessage))]
	interface MPABTestDesignerDisconnectMessage {

	}

	// @interface MPABTestDesignerSnapshotRequestMessage : MPAbstractABTestDesignerMessage
	[BaseType (typeof (MPAbstractABTestDesignerMessage))]
	interface MPABTestDesignerSnapshotRequestMessage {

		// @property (readonly, nonatomic) MPObjectSerializerConfig * configuration;
		[Export ("configuration")]
		MPObjectSerializerConfig Configuration { get; }

		// +(instancetype)message;
		[Static, Export ("message")]
		MPABTestDesignerSnapshotRequestMessage Message ();
	}

	// @interface MPABTestDesignerSnapshotResponseMessage : MPAbstractABTestDesignerMessage
	[BaseType (typeof (MPAbstractABTestDesignerMessage))]
	interface MPABTestDesignerSnapshotResponseMessage {

		// @property (nonatomic, strong) UIImage * screenshot;
		[Export ("screenshot", ArgumentSemantic.Retain)]
		UIImage Screenshot { get; set; }

		// @property (copy, nonatomic) NSDictionary * serializedObjects;
		[Export ("serializedObjects", ArgumentSemantic.Copy)]
		NSDictionary SerializedObjects { get; set; }

		// @property (readonly, nonatomic, strong) NSString * imageHash;
		[Export ("imageHash", ArgumentSemantic.Retain)]
		string ImageHash { get; }

		// +(instancetype)message;
		[Static, Export ("message")]
		MPABTestDesignerSnapshotResponseMessage Message ();
	}

	// @interface MPABTestDesignerTweakRequestMessage : MPAbstractABTestDesignerMessage
	[BaseType (typeof (MPAbstractABTestDesignerMessage))]
	interface MPABTestDesignerTweakRequestMessage {

	}

	// @interface MPABTestDesignerTweakResponseMessage : MPAbstractABTestDesignerMessage
	[BaseType (typeof (MPAbstractABTestDesignerMessage))]
	interface MPABTestDesignerTweakResponseMessage {

		// @property (copy, nonatomic) NSString * status;
		[Export ("status")]
		string Status { get; set; }

		// +(instancetype)message;
		[Static, Export ("message")]
		MPABTestDesignerTweakResponseMessage Message ();
	}

	// @interface MPApplicationStateSerializer : NSObject
	[BaseType (typeof (NSObject))]
	interface MPApplicationStateSerializer {

		// -(id)initWithApplication:(UIApplication *)application configuration:(MPObjectSerializerConfig *)configuration objectIdentityProvider:(MPObjectIdentityProvider *)objectIdentityProvider;
		[Export ("initWithApplication:configuration:objectIdentityProvider:")]
		IntPtr Constructor (UIApplication application, MPObjectSerializerConfig configuration, MPObjectIdentityProvider objectIdentityProvider);

		// -(UIImage *)screenshotImageForWindowAtIndex:(NSUInteger)index;
		[Export ("screenshotImageForWindowAtIndex:")]
		UIImage ScreenshotImageForWindowAtIndex (nuint index);

		// -(NSDictionary *)objectHierarchyForWindowAtIndex:(NSUInteger)index;
		[Export ("objectHierarchyForWindowAtIndex:")]
		NSDictionary ObjectHierarchyForWindowAtIndex (nuint index);
	}

	// @interface MPHelpers (UIView)
	[Category]
	[BaseType (typeof (UIView))]
	interface MPHelpers {

		// -(UIImage *)mp_snapshotImage;
		[Export ("mp_snapshotImage")]
		UIImage Mp_snapshotImage ();

		// -(UIImage *)mp_snapshotForBlur;
		[Export ("mp_snapshotForBlur")]
		UIImage Mp_snapshotForBlur ();

		// -(int)mp_fingerprintVersion;
		[Export ("mp_fingerprintVersion")]
		int Mp_fingerprintVersion ();

		// -(void)mp_setArgumentsFromArray:(NSArray *)argumentArray;
		[Export ("mp_setArgumentsFromArray:")]
		void Mp_setArgumentsFromArray (NSObject [] argumentArray);

		// -(id)mp_returnValue;
		[Export ("mp_returnValue")]
		NSObject Mp_returnValue ();
	}

	// @interface MPTypeDescription : NSObject
	[BaseType (typeof (NSObject))]
	interface MPTypeDescription {

		// -(id)initWithDictionary:(NSDictionary *)dictionary;
		[Export ("initWithDictionary:")]
		IntPtr Constructor (NSDictionary dictionary);

		// @property (readonly, nonatomic) NSString * name;
		[Export ("name")]
		string Name { get; }
	}

	// @interface MPClassDescription : MPTypeDescription
	[BaseType (typeof (MPTypeDescription))]
	interface MPClassDescription {

		// -(id)initWithSuperclassDescription:(MPClassDescription *)superclassDescription dictionary:(NSDictionary *)dictionary;
		[Export ("initWithSuperclassDescription:dictionary:")]
		IntPtr Constructor (MPClassDescription superclassDescription, NSDictionary dictionary);

		// @property (readonly, nonatomic) MPClassDescription * superclassDescription;
		[Export ("superclassDescription")]
		MPClassDescription SuperclassDescription { get; }

		// @property (readonly, nonatomic) NSArray * propertyDescriptions;
		[Export ("propertyDescriptions")]
		NSObject [] PropertyDescriptions { get; }

		// @property (readonly, nonatomic) NSArray * delegateInfos;
		[Export ("delegateInfos")]
		NSObject [] DelegateInfos { get; }

		// -(BOOL)isDescriptionForKindOfClass:(Class)class;
		[Export ("isDescriptionForKindOfClass:")]
		bool IsDescriptionForKindOfClass (Class c);
	}

	// @interface MPDelegateInfo : NSObject
	[BaseType (typeof (NSObject))]
	interface MPDelegateInfo {

		// -(id)initWithDictionary:(NSDictionary *)dictionary;
		[Export ("initWithDictionary:")]
		IntPtr Constructor (NSDictionary dictionary);

		// @property (readonly, nonatomic) NSString * selectorName;
		[Export ("selectorName")]
		string SelectorName { get; }
	}

	// @interface MPDesignerEventBindingRequestMesssage : MPAbstractABTestDesignerMessage
	[BaseType (typeof (MPAbstractABTestDesignerMessage))]
	interface MPDesignerEventBindingRequestMesssage {

	}

	// @interface MPDesignerEventBindingResponseMesssage : MPAbstractABTestDesignerMessage
	[BaseType (typeof (MPAbstractABTestDesignerMessage))]
	interface MPDesignerEventBindingResponseMesssage {

		// @property (copy, nonatomic) NSString * status;
		[Export ("status")]
		string Status { get; set; }

		// +(instancetype)message;
		[Static, Export ("message")]
		MPDesignerEventBindingResponseMesssage Message ();
	}

	// @interface MPDesignerTrackMessage : MPAbstractABTestDesignerMessage
	[BaseType (typeof (MPAbstractABTestDesignerMessage))]
	interface MPDesignerTrackMessage {

		// +(instancetype)message;
		[Static, Export ("message")]
		MPDesignerTrackMessage Message ();

		// +(instancetype)messageWithPayload:(NSDictionary *)payload;
		[Static, Export ("messageWithPayload:")]
		MPDesignerTrackMessage MessageWithPayload (NSDictionary payload);
	}

	// @protocol MPDesignerSessionCollection <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface MPDesignerSessionCollection {

		// @required -(void)cleanup;
		[Export ("cleanup")]
		[Abstract]
		void Cleanup ();
	}

	// @interface MPEnumDescription : MPTypeDescription
	[BaseType (typeof (MPTypeDescription))]
	interface MPEnumDescription {

		// @property (readonly, assign, nonatomic, getter = isFlagsSet) BOOL flagSet;
		[Export ("flagSet", ArgumentSemantic.UnsafeUnretained)]
		bool FlagSet { [Bind ("isFlagsSet")] get; }

		// @property (readonly, copy, nonatomic) NSString * baseType;
		[Export ("baseType")]
		string BaseType { get; }

		// -(NSArray *)allValues;
		[Export ("allValues")]
		NSObject [] AllValues ();
	}

	// @interface MPObjectSelector : NSObject
	[BaseType (typeof (NSObject))]
	interface MPObjectSelector {

		// -(id)initWithString:(NSString *)string;
		[Export ("initWithString:")]
		IntPtr Constructor (string s);

		// @property (readonly, nonatomic, strong) NSString * string;
		[Export ("string", ArgumentSemantic.Retain)]
		string String { get; }

		// +(MPObjectSelector *)objectSelectorWithString:(NSString *)string;
		[Static, Export ("objectSelectorWithString:")]
		MPObjectSelector ObjectSelectorWithString (string s);

		// -(NSArray *)selectFromRoot:(id)root;
		[Export ("selectFromRoot:")]
		NSObject [] SelectFromRoot (NSObject root);

		// -(NSArray *)fuzzySelectFromRoot:(id)root;
		[Export ("fuzzySelectFromRoot:")]
		NSObject [] FuzzySelectFromRoot (NSObject root);

		// -(BOOL)isLeafSelected:(id)leaf fromRoot:(id)root;
		[Export ("isLeafSelected:fromRoot:")]
		bool IsLeafSelected (NSObject leaf, NSObject root);

		// -(BOOL)fuzzyIsLeafSelected:(id)leaf fromRoot:(id)root;
		[Export ("fuzzyIsLeafSelected:fromRoot:")]
		bool FuzzyIsLeafSelected (NSObject leaf, NSObject root);

		// -(Class)selectedClass;
		[Export ("selectedClass")]
		Class SelectedClass ();

		// -(NSString *)description;
		[Export ("description")]
		string Description ();
	}

	// @interface MPEventBinding : NSObject <NSCoding>
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface MPEventBinding : NSCoding {

		// -(id)initWithEventName:(NSString *)eventName onPath:(NSString *)path;
		[Export ("initWithEventName:onPath:")]
		IntPtr Constructor (string eventName, string path);

		// @property (nonatomic) NSUInteger ID;
		[Export ("ID")]
		nuint ID { get; set; }

		// @property (nonatomic) NSString * name;
		[Export ("name")]
		string Name { get; set; }

		// @property (nonatomic) MPObjectSelector * path;
		[Export ("path")]
		MPObjectSelector Path { get; set; }

		// @property (nonatomic) NSString * eventName;
		[Export ("eventName")]
		string EventName { get; set; }

		// @property (assign, nonatomic) Class swizzleClass;
		[Export ("swizzleClass", ArgumentSemantic.UnsafeUnretained)]
		Class SwizzleClass { get; set; }

		// @property (nonatomic) BOOL running;
		[Export ("running")]
		bool Running { get; set; }

		// +(id)bindngWithJSONObject:(id)object;
		[Static, Export ("bindngWithJSONObject:")]
		NSObject BindngWithJSONObject (NSObject o);

		// +(void)track:(NSString *)event properties:(NSDictionary *)properties;
		[Static, Export ("track:properties:")]
		void Track (string e, NSDictionary properties);

		// +(NSString *)typeName;
		[Static, Export ("typeName")]
		string TypeName ();

		// -(void)execute;
		[Export ("execute")]
		void Execute ();

		// -(void)stop;
		[Export ("stop")]
		void Stop ();
	}

	// @interface MPNotification : NSObject
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface MPNotification {

		// @property (readonly, nonatomic) NSUInteger ID;
		[Export ("ID")]
		nuint ID { get; }

		// @property (readonly, nonatomic) NSUInteger messageID;
		[Export ("messageID")]
		nuint MessageID { get; }

		// @property (nonatomic, strong) NSString * type;
		[Export ("type", ArgumentSemantic.Retain)]
		string Type { get; set; }

		// @property (nonatomic, strong) NSURL * imageURL;
		[Export ("imageURL", ArgumentSemantic.Retain)]
		NSUrl ImageURL { get; set; }

		// @property (nonatomic, strong) NSData * image;
		[Export ("image", ArgumentSemantic.Retain)]
		NSData Image { get; set; }

		// @property (nonatomic, strong) NSString * title;
		[Export ("title", ArgumentSemantic.Retain)]
		string Title { get; set; }

		// @property (nonatomic, strong) NSString * body;
		[Export ("body", ArgumentSemantic.Retain)]
		string Body { get; set; }

		// @property (nonatomic, strong) NSString * callToAction;
		[Export ("callToAction", ArgumentSemantic.Retain)]
		string CallToAction { get; set; }

		// @property (nonatomic, strong) NSURL * callToActionURL;
		[Export ("callToActionURL", ArgumentSemantic.Retain)]
		NSUrl CallToActionURL { get; set; }

		// +(MPNotification *)notificationWithJSONObject:(NSDictionary *)object;
		[Static, Export ("notificationWithJSONObject:")]
		MPNotification NotificationWithJSONObject (NSDictionary o);
	}

	// @interface MPNotificationViewController : UIViewController
	[BaseType (typeof (UIViewController))]
	interface MPNotificationViewController {

		// @property (nonatomic, strong) MPNotification * notification;
		[Export ("notification", ArgumentSemantic.Retain)]
		MPNotification Notification { get; set; }

		// @property (nonatomic, weak) id<MPNotificationViewControllerDelegate> delegate;
		[Export ("delegate", ArgumentSemantic.Weak)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic, weak) id<MPNotificationViewControllerDelegate> delegate;
		[Wrap ("WeakDelegate")]
		MPNotificationViewControllerDelegate Delegate { get; set; }

		// -(void)hideWithAnimation:(BOOL)animated completion:(void (^)(void))completion;
		[Export ("hideWithAnimation:completion:")]
		void HideWithAnimation (bool animated, Action completion);
	}

	// @interface MPTakeoverNotificationViewController : MPNotificationViewController
	[BaseType (typeof (MPNotificationViewController))]
	interface MPTakeoverNotificationViewController {

		// @property (nonatomic, strong) UIImage * backgroundImage;
		[Export ("backgroundImage", ArgumentSemantic.Retain)]
		UIImage BackgroundImage { get; set; }
	}

	// @interface MPMiniNotificationViewController : MPNotificationViewController
	[BaseType (typeof (MPNotificationViewController))]
	interface MPMiniNotificationViewController {

		// -(void)showWithAnimation;
		[Export ("showWithAnimation")]
		void ShowWithAnimation ();
	}

	// @protocol MPNotificationViewControllerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface MPNotificationViewControllerDelegate {

		// @required -(void)notificationController:(MPNotificationViewController *)controller wasDismissedWithStatus:(BOOL)status;
		[Export ("notificationController:wasDismissedWithStatus:")]
		[Abstract]
		void WasDismissedWithStatus (MPNotificationViewController controller, bool status);
	}

	// @protocol MPObjectIdentifierProvider <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface MPObjectIdentifierProvider {

		// @required -(NSString *)identifierForObject:(id)object;
		[Export ("identifierForObject:")]
		[Abstract]
		string IdentifierForObject (NSObject o);
	}

	// @interface MPObjectIdentityProvider : NSObject
	[BaseType (typeof (NSObject))]
	interface MPObjectIdentityProvider {

		// -(NSString *)identifierForObject:(id)object;
		[Export ("identifierForObject:")]
		string IdentifierForObject (NSObject o);
	}

	// @interface MPObjectSerializer : NSObject
	[BaseType (typeof (NSObject))]
	interface MPObjectSerializer {

		// -(id)initWithConfiguration:(MPObjectSerializerConfig *)configuration objectIdentityProvider:(MPObjectIdentityProvider *)objectIdentityProvider;
		[Export ("initWithConfiguration:objectIdentityProvider:")]
		IntPtr Constructor (MPObjectSerializerConfig configuration, MPObjectIdentityProvider objectIdentityProvider);

		// -(NSDictionary *)serializedObjectsWithRootObject:(id)rootObject;
		[Export ("serializedObjectsWithRootObject:")]
		NSDictionary SerializedObjectsWithRootObject (NSObject rootObject);
	}

	// @interface MPObjectSerializerConfig : NSObject
	[BaseType (typeof (NSObject))]
	interface MPObjectSerializerConfig {

		// -(id)initWithDictionary:(NSDictionary *)dictionary;
		[Export ("initWithDictionary:")]
		IntPtr Constructor (NSDictionary dictionary);

		// @property (readonly, nonatomic) NSArray * classDescriptions;
		[Export ("classDescriptions")]
		NSObject [] ClassDescriptions { get; }

		// @property (readonly, nonatomic) NSArray * enumDescriptions;
		[Export ("enumDescriptions")]
		NSObject [] EnumDescriptions { get; }

		// -(MPTypeDescription *)typeWithName:(NSString *)name;
		[Export ("typeWithName:")]
		MPTypeDescription TypeWithName (string name);

		// -(MPEnumDescription *)enumWithName:(NSString *)name;
		[Export ("enumWithName:")]
		MPEnumDescription EnumWithName (string name);

		// -(MPClassDescription *)classWithName:(NSString *)name;
		[Export ("classWithName:")]
		MPClassDescription ClassWithName (string name);
	}

	// @interface MPObjectSerializerContext : NSObject
	[BaseType (typeof (NSObject))]
	interface MPObjectSerializerContext {

		// -(id)initWithRootObject:(id)object;
		[Export ("initWithRootObject:")]
		IntPtr Constructor (NSObject o);

		// -(BOOL)hasUnvisitedObjects;
		[Export ("hasUnvisitedObjects")]
		bool HasUnvisitedObjects ();

		// -(void)enqueueUnvisitedObject:(NSObject *)object;
		[Export ("enqueueUnvisitedObject:")]
		void EnqueueUnvisitedObject (NSObject o);

		// -(NSObject *)dequeueUnvisitedObject;
		[Export ("dequeueUnvisitedObject")]
		NSObject DequeueUnvisitedObject ();

		// -(void)addVisitedObject:(NSObject *)object;
		[Export ("addVisitedObject:")]
		void AddVisitedObject (NSObject o);

		// -(BOOL)isVisitedObject:(NSObject *)object;
		[Export ("isVisitedObject:")]
		bool IsVisitedObject (NSObject o);

		// -(void)addSerializedObject:(NSDictionary *)serializedObject;
		[Export ("addSerializedObject:")]
		void AddSerializedObject (NSDictionary serializedObject);

		// -(NSArray *)allSerializedObjects;
		[Export ("allSerializedObjects")]
		NSObject [] AllSerializedObjects ();
	}

	// @interface MPPropertySelectorParameterDescription : NSObject
	[BaseType (typeof (NSObject))]
	interface MPPropertySelectorParameterDescription {

		// -(id)initWithDictionary:(NSDictionary *)dictionary;
		[Export ("initWithDictionary:")]
		IntPtr Constructor (NSDictionary dictionary);

		// @property (readonly, nonatomic) NSString * name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, nonatomic) NSString * type;
		[Export ("type")]
		string Type { get; }
	}

	// @interface MPPropertySelectorDescription : NSObject
	[BaseType (typeof (NSObject))]
	interface MPPropertySelectorDescription {

		// -(id)initWithDictionary:(NSDictionary *)dictionary;
		[Export ("initWithDictionary:")]
		IntPtr Constructor (NSDictionary dictionary);

		// @property (readonly, nonatomic) NSString * selectorName;
		[Export ("selectorName")]
		string SelectorName { get; }

		// @property (readonly, nonatomic) NSString * returnType;
		[Export ("returnType")]
		string ReturnType { get; }

		// @property (readonly, nonatomic) NSArray * parameters;
		[Export ("parameters")]
		NSObject [] Parameters { get; }
	}

	// @interface MPPropertyDescription : NSObject
	[BaseType (typeof (NSObject))]
	interface MPPropertyDescription {

		// -(id)initWithDictionary:(NSDictionary *)dictionary;
		[Export ("initWithDictionary:")]
		IntPtr Constructor (NSDictionary dictionary);

		// @property (readonly, nonatomic) NSString * type;
		[Export ("type")]
		string Type { get; }

		// @property (readonly, nonatomic) BOOL readonly;
		[Export ("readonly")]
		bool Readonly { get; }

		// @property (readonly, nonatomic) BOOL nofollow;
		[Export ("nofollow")]
		bool Nofollow { get; }

		// @property (readonly, nonatomic) BOOL useKeyValueCoding;
		[Export ("useKeyValueCoding")]
		bool UseKeyValueCoding { get; }

		// @property (readonly, nonatomic) BOOL useInstanceVariableAccess;
		[Export ("useInstanceVariableAccess")]
		bool UseInstanceVariableAccess { get; }

		// @property (readonly, nonatomic) NSString * name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, nonatomic) MPPropertySelectorDescription * getSelectorDescription;
		[Export ("getSelectorDescription")]
		MPPropertySelectorDescription GetSelectorDescription { get; }

		// @property (readonly, nonatomic) MPPropertySelectorDescription * setSelectorDescription;
		[Export ("setSelectorDescription")]
		MPPropertySelectorDescription SetSelectorDescription { get; }

		// -(BOOL)shouldReadPropertyValueForObject:(NSObject *)object;
		[Export ("shouldReadPropertyValueForObject:")]
		bool ShouldReadPropertyValueForObject (NSObject o);

		// -(NSValueTransformer *)valueTransformer;
		[Export ("valueTransformer")]
		NSValueTransformer ValueTransformer ();
	}

	// @interface MPSequenceGenerator : NSObject
	[BaseType (typeof (NSObject))]
	interface MPSequenceGenerator {

		// -(int32_t)nextValue;
		[Export ("nextValue")]
		int NextValue ();
	}

	// @interface MPSurvey : NSObject
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface MPSurvey {

		// @property (readonly, nonatomic) NSUInteger ID;
		[Export ("ID")]
		nuint ID { get; }

		// @property (readonly, nonatomic, strong) NSString * name;
		[Export ("name", ArgumentSemantic.Retain)]
		string Name { get; }

		// @property (readonly, nonatomic) NSUInteger collectionID;
		[Export ("collectionID")]
		nuint CollectionID { get; }

		// @property (readonly, nonatomic, strong) NSArray * questions;
		[Export ("questions", ArgumentSemantic.Retain)]
		NSObject [] Questions { get; }

		// +(MPSurvey *)surveyWithJSONObject:(NSDictionary *)object;
		[Static, Export ("surveyWithJSONObject:")]
		MPSurvey SurveyWithJSONObject (NSDictionary o);
	}
	*/

	// @interface Mixpanel : NSObject
	[BaseType (typeof (NSObject))]
	interface Mixpanel {

		// -(instancetype)initWithToken:(NSString *)apiToken launchOptions:(NSDictionary *)launchOptions andFlushInterval:(NSUInteger)flushInterval;
		[Export ("initWithToken:launchOptions:andFlushInterval:")]
		IntPtr Constructor (string apiToken, NSDictionary launchOptions, nuint flushInterval);

		// -(instancetype)initWithToken:(NSString *)apiToken andFlushInterval:(NSUInteger)flushInterval;
		[Export ("initWithToken:andFlushInterval:")]
		IntPtr Constructor (string apiToken, nuint flushInterval);

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
		nuint FlushInterval { get; set; }

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
		nfloat MiniNotificationPresentationTime { get; set; }

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
		void ShowSurveyWithID (nuint ID);

		// -(void)showSurvey;
		[Export ("showSurvey")]
		void ShowSurvey ();

		// -(void)showNotificationWithID:(NSUInteger)ID;
		[Export ("showNotificationWithID:")]
		void ShowNotificationWithID (nuint ID);

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

	/*
	// @interface MPSurveyNavigationController : UIViewController
	[BaseType (typeof (UIViewController))]
	interface MPSurveyNavigationController {

		// @property (nonatomic, strong) MPSurvey * survey;
		[Export ("survey", ArgumentSemantic.Retain)]
		MPSurvey Survey { get; set; }

		// @property (nonatomic, strong) UIImage * backgroundImage;
		[Export ("backgroundImage", ArgumentSemantic.Retain)]
		UIImage BackgroundImage { get; set; }

		// @property (nonatomic, weak) id<MPSurveyNavigationControllerDelegate> delegate;
		[Export ("delegate", ArgumentSemantic.Weak)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic, weak) id<MPSurveyNavigationControllerDelegate> delegate;
		[Wrap ("WeakDelegate")]
		MPSurveyNavigationControllerDelegate Delegate { get; set; }
	}

	// @protocol MPSurveyNavigationControllerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface MPSurveyNavigationControllerDelegate {

		// @required -(void)surveyController:(MPSurveyNavigationController *)controller wasDismissedWithAnswers:(NSArray *)answers;
		[Export ("surveyController:wasDismissedWithAnswers:")]
		[Abstract]
		void WasDismissedWithAnswers (MPSurveyNavigationController controller, NSObject [] answers);
	}

	// @interface MPSurveyQuestion : NSObject
	[BaseType (typeof (NSObject))]
	interface MPSurveyQuestion {

		// @property (readonly, nonatomic) NSUInteger ID;
		[Export ("ID")]
		nuint ID { get; }

		// @property (readonly, nonatomic, strong) NSString * type;
		[Export ("type", ArgumentSemantic.Retain)]
		string Type { get; }

		// @property (readonly, nonatomic, strong) NSString * prompt;
		[Export ("prompt", ArgumentSemantic.Retain)]
		string Prompt { get; }

		// +(MPSurveyQuestion *)questionWithJSONObject:(NSObject *)object;
		[Static, Export ("questionWithJSONObject:")]
		MPSurveyQuestion QuestionWithJSONObject (NSObject o);
	}

	// @interface MPSurveyMultipleChoiceQuestion : MPSurveyQuestion
	[BaseType (typeof (MPSurveyQuestion))]
	interface MPSurveyMultipleChoiceQuestion {

		// @property (readonly, nonatomic, strong) NSArray * choices;
		[Export ("choices", ArgumentSemantic.Retain)]
		NSObject [] Choices { get; }
	}

	// @interface MPSurveyTextQuestion : MPSurveyQuestion
	[BaseType (typeof (MPSurveyQuestion))]
	interface MPSurveyTextQuestion {

	}

	// @interface MPSurveyQuestionViewController : UIViewController
	[BaseType (typeof (UIViewController))]
	interface MPSurveyQuestionViewController {

		// @property (nonatomic, weak) id<MPSurveyQuestionViewControllerDelegate> delegate;
		[Export ("delegate", ArgumentSemantic.Weak)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic, weak) id<MPSurveyQuestionViewControllerDelegate> delegate;
		[Wrap ("WeakDelegate")]
		MPSurveyQuestionViewControllerDelegate Delegate { get; set; }

		// @property (nonatomic, strong) MPSurveyQuestion * question;
		[Export ("question", ArgumentSemantic.Retain)]
		MPSurveyQuestion Question { get; set; }

		// @property (nonatomic, strong) UIColor * highlightColor;
		[Export ("highlightColor", ArgumentSemantic.Retain)]
		UIColor HighlightColor { get; set; }
	}

	// @protocol MPSurveyQuestionViewControllerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface MPSurveyQuestionViewControllerDelegate {

		// @required -(void)questionController:(MPSurveyQuestionViewController *)controller didReceiveAnswerProperties:(NSDictionary *)properties;
		[Export ("questionController:didReceiveAnswerProperties:")]
		[Abstract]
		void DidReceiveAnswerProperties (MPSurveyQuestionViewController controller, NSDictionary properties);
	}

	// @interface MPSwizzler : NSObject
	[BaseType (typeof (NSObject))]
	interface MPSwizzler {

		// +(void)swizzleSelector:(SEL)aSelector onClass:(Class)aClass withBlock:(swizzleBlock)block named:(NSString *)aName;
		[Static, Export ("swizzleSelector:onClass:withBlock:named:")]
		void SwizzleSelector (Selector aSelector, Class aClass, Action block, string aName);

		// +(void)unswizzleSelector:(SEL)aSelector onClass:(Class)aClass named:(NSString *)aName;
		[Static, Export ("unswizzleSelector:onClass:named:")]
		void UnswizzleSelector (Selector aSelector, Class aClass, string aName);

		// +(void)printSwizzles;
		[Static, Export ("printSwizzles")]
		void PrintSwizzles ();
	}

	// @interface MPTweak : NSObject
	[BaseType (typeof (NSObject))]
	interface MPTweak {

		// -(instancetype)initWithName:(NSString *)name andEncoding:(NSString *)encoding;
		[Export ("initWithName:andEncoding:")]
		IntPtr Constructor (string name, string encoding);

		// @property (readonly, copy, nonatomic) NSString * name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSString * encoding;
		[Export ("encoding")]
		string Encoding { get; }

		// @property (readwrite, nonatomic, strong) MPTweakValue defaultValue;
		[Export ("defaultValue", ArgumentSemantic.Retain)]
		NSObject DefaultValue { get; set; }

		// @property (readwrite, nonatomic, strong) MPTweakValue currentValue;
		[Export ("currentValue", ArgumentSemantic.Retain)]
		NSObject CurrentValue { get; set; }

		// @property (readwrite, nonatomic, strong) MPTweakValue minimumValue;
		[Export ("minimumValue", ArgumentSemantic.Retain)]
		NSObject MinimumValue { get; set; }

		// @property (readwrite, nonatomic, strong) MPTweakValue maximumValue;
		[Export ("maximumValue", ArgumentSemantic.Retain)]
		NSObject MaximumValue { get; set; }

		// -(void)addObserver:(id<MPTweakObserver>)observer;
		[Export ("addObserver:")]
		void AddObserver (MPTweakObserver observer);

		// -(void)removeObserver:(id<MPTweakObserver>)observer;
		[Export ("removeObserver:")]
		void RemoveObserver (MPTweakObserver observer);
	}

	// @protocol MPTweakObserver <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface MPTweakObserver {

		// @required -(void)tweakDidChange:(MPTweak *)tweak;
		[Export ("tweakDidChange:")]
		[Abstract]
		void TweakDidChange (MPTweak tweak);
	}

	// @interface _MPTweakBindObserver : NSObject
	[BaseType (typeof (NSObject))]
	interface _MPTweakBindObserver {

		// -(instancetype)initWithTweak:(MPTweak *)tweak block:(_MPTweakBindObserverBlock)block;
		[Export ("initWithTweak:block:")]
		IntPtr Constructor (MPTweak tweak, Action<NSObject> block);

		// -(void)attachToObject:(id)object;
		[Export ("attachToObject:")]
		void AttachToObject (NSObject o);
	}

	// @interface MPTweakStore : NSObject
	[BaseType (typeof (NSObject))]
	interface MPTweakStore {

		// @property (readonly, copy, nonatomic) NSArray * tweaks;
		[Export ("tweaks", ArgumentSemantic.Copy)]
		NSObject [] Tweaks { get; }

		// +(instancetype)sharedInstance;
		[Static, Export ("sharedInstance")]
		MPTweakStore SharedInstance ();

		// -(MPTweak *)tweakWithName:(NSString *)name;
		[Export ("tweakWithName:")]
		MPTweak TweakWithName (string name);

		// -(void)addTweak:(MPTweak *)tweak;
		[Export ("addTweak:")]
		void AddTweak (MPTweak tweak);

		// -(void)removeTweak:(MPTweak *)tweak;
		[Export ("removeTweak:")]
		void RemoveTweak (MPTweak tweak);

		// -(void)reset;
		[Export ("reset")]
		void Reset ();
	}

	// @interface MPUIControlBinding : MPEventBinding
	[BaseType (typeof (MPEventBinding))]
	[DisableDefaultCtor]
	interface MPUIControlBinding {

		// -(id)initWithEventName:(NSString *)eventName onPath:(NSString *)path withControlEvent:(UIControlEvents)controlEvent andVerifyEvent:(UIControlEvents)verifyEvent;
		[Export ("initWithEventName:onPath:withControlEvent:andVerifyEvent:")]
		IntPtr Constructor (string eventName, string path, UIControlEvents controlEvent, UIControlEvents verifyEvent);

		// @property (readonly, nonatomic) UIControlEvents controlEvent;
		[Export ("controlEvent")]
		UIControlEvents ControlEvent { get; }

		// @property (readonly, nonatomic) UIControlEvents verifyEvent;
		[Export ("verifyEvent")]
		UIControlEvents VerifyEvent { get; }
	}

	// @interface MPUITableViewBinding : MPEventBinding
	[BaseType (typeof (MPEventBinding))]
	[DisableDefaultCtor]
	interface MPUITableViewBinding {

		// -(instancetype)initWithEventName:(NSString *)eventName onPath:(NSString *)path withDelegate:(Class)delegateClass;
		[Export ("initWithEventName:onPath:withDelegate:")]
		IntPtr Constructor (string eventName, string path, Class delegateClass);
	}

	// @interface MPPassThroughValueTransformer : NSValueTransformer
	[BaseType (typeof (NSValueTransformer))]
	interface MPPassThroughValueTransformer {

	}

	// @interface MPBOOLToNSNumberValueTransformer : NSValueTransformer
	[BaseType (typeof (NSValueTransformer))]
	interface MPBOOLToNSNumberValueTransformer {

	}

	// @interface MPCATransform3DToNSDictionaryValueTransformer : NSValueTransformer
	[BaseType (typeof (NSValueTransformer))]
	interface MPCATransform3DToNSDictionaryValueTransformer {

	}

	// @interface MPCGAffineTransformToNSDictionaryValueTransformer : NSValueTransformer
	[BaseType (typeof (NSValueTransformer))]
	interface MPCGAffineTransformToNSDictionaryValueTransformer {

	}

	// @interface MPCGColorRefToNSStringValueTransformer : NSValueTransformer
	[BaseType (typeof (NSValueTransformer))]
	interface MPCGColorRefToNSStringValueTransformer {

	}

	// @interface MPCGPointToNSDictionaryValueTransformer : NSValueTransformer
	[BaseType (typeof (NSValueTransformer))]
	interface MPCGPointToNSDictionaryValueTransformer {

	}

	// @interface MPCGRectToNSDictionaryValueTransformer : NSValueTransformer
	[BaseType (typeof (NSValueTransformer))]
	interface MPCGRectToNSDictionaryValueTransformer {

	}

	// @interface MPCGSizeToNSDictionaryValueTransformer : NSValueTransformer
	[BaseType (typeof (NSValueTransformer))]
	interface MPCGSizeToNSDictionaryValueTransformer {

	}

	// @interface MPNSAttributedStringToNSDictionaryValueTransformer : NSValueTransformer
	[BaseType (typeof (NSValueTransformer))]
	interface MPNSAttributedStringToNSDictionaryValueTransformer {

	}

	// @interface MPUIColorToNSStringValueTransformer : NSValueTransformer
	[BaseType (typeof (NSValueTransformer))]
	interface MPUIColorToNSStringValueTransformer {

	}

	// @interface MPUIEdgeInsetsToNSDictionaryValueTransformer : NSValueTransformer
	[BaseType (typeof (NSValueTransformer))]
	interface MPUIEdgeInsetsToNSDictionaryValueTransformer {

	}

	// @interface MPUIFontToNSDictionaryValueTransformer : NSValueTransformer
	[BaseType (typeof (NSValueTransformer))]
	interface MPUIFontToNSDictionaryValueTransformer {

	}

	// @interface MPUIImageToNSDictionaryValueTransformer : NSValueTransformer
	[BaseType (typeof (NSValueTransformer))]
	interface MPUIImageToNSDictionaryValueTransformer {

	}

	// @interface MPNSNumberToCGFloatValueTransformer : NSValueTransformer
	[BaseType (typeof (NSValueTransformer))]
	interface MPNSNumberToCGFloatValueTransformer {

	}

	// @interface MPVariant : NSObject <NSCoding>
	[BaseType (typeof (NSObject))]
	interface MPVariant : NSCoding {

		// @property (nonatomic) NSUInteger ID;
		[Export ("ID")]
		nuint ID { get; set; }

		// @property (nonatomic) NSUInteger experimentID;
		[Export ("experimentID")]
		nuint ExperimentID { get; set; }

		// @property (readonly, nonatomic) BOOL running;
		[Export ("running")]
		bool Running { get; }

		// @property (readonly, nonatomic) BOOL finished;
		[Export ("finished")]
		bool Finished { get; }

		// +(MPVariant *)variantWithJSONObject:(NSDictionary *)object;
		[Static, Export ("variantWithJSONObject:")]
		MPVariant VariantWithJSONObject (NSDictionary o);

		// -(void)addActionsFromJSONObject:(NSArray *)actions andExecute:(BOOL)exec;
		[Export ("addActionsFromJSONObject:andExecute:")]
		void AddActionsFromJSONObject (NSObject [] actions, bool exec);

		// -(void)addActionFromJSONObject:(NSDictionary *)object andExecute:(BOOL)exec;
		[Export ("addActionFromJSONObject:andExecute:")]
		void AddActionFromJSONObject (NSDictionary o, bool exec);

		// -(void)addTweaksFromJSONObject:(NSArray *)tweaks andExecute:(BOOL)exec;
		[Export ("addTweaksFromJSONObject:andExecute:")]
		void AddTweaksFromJSONObject (NSObject [] tweaks, bool exec);

		// -(void)addTweakFromJSONObject:(NSDictionary *)object andExecute:(BOOL)exec;
		[Export ("addTweakFromJSONObject:andExecute:")]
		void AddTweakFromJSONObject (NSDictionary o, bool exec);

		// -(void)removeActionWithName:(NSString *)name;
		[Export ("removeActionWithName:")]
		void RemoveActionWithName (string name);

		// -(void)execute;
		[Export ("execute")]
		void Execute ();

		// -(void)stop;
		[Export ("stop")]
		void Stop ();

		// -(void)finish;
		[Export ("finish")]
		void Finish ();

		// -(void)restart;
		[Export ("restart")]
		void Restart ();
	}

	// @interface MPVariantAction : NSObject <NSCoding>
	[BaseType (typeof (NSObject))]
	interface MPVariantAction : NSCoding {

	}

	// @interface MPVariantTweak : NSObject <NSCoding>
	[BaseType (typeof (NSObject))]
	interface MPVariantTweak : NSCoding {

	}

	// @interface MP_Base64 (NSData)
	[Category]
	[BaseType (typeof (NSData))]
	interface MP_Base64 {

		// +(NSData *)mp_dataFromBase64String:(NSString *)aString;
		[Static, Export ("mp_dataFromBase64String:")]
		NSData Mp_dataFromBase64String (string aString);

		// -(NSString *)mp_base64EncodedString;
		[Export ("mp_base64EncodedString")]
		string Mp_base64EncodedString ();
	}

	// @interface MPColor (UIColor)
	[Category]
	[BaseType (typeof (UIColor))]
	interface MPColor {

		// +(UIColor *)mp_applicationPrimaryColor;
		[Static, Export ("mp_applicationPrimaryColor")]
		UIColor Mp_applicationPrimaryColor ();

		// +(UIColor *)mp_lightEffectColor;
		[Static, Export ("mp_lightEffectColor")]
		UIColor Mp_lightEffectColor ();

		// +(UIColor *)mp_extraLightEffectColor;
		[Static, Export ("mp_extraLightEffectColor")]
		UIColor Mp_extraLightEffectColor ();

		// +(UIColor *)mp_darkEffectColor;
		[Static, Export ("mp_darkEffectColor")]
		UIColor Mp_darkEffectColor ();

		// -(UIColor *)colorWithSaturationComponent:(CGFloat)saturation;
		[Export ("colorWithSaturationComponent:")]
		UIColor ColorWithSaturationComponent (nfloat saturation);
	}

	// @interface MPAverageColor (UIImage)
	[Category]
	[BaseType (typeof (UIImage))]
	interface MPAverageColor {

		// -(UIColor *)mp_averageColor;
		[Export ("mp_averageColor")]
		UIColor Mp_averageColor ();

		// -(UIColor *)mp_importantColor;
		[Export ("mp_importantColor")]
		UIColor Mp_importantColor ();
	}

	// @interface MPImageEffects (UIImage)
	[Category]
	[BaseType (typeof (UIImage))]
	interface MPImageEffects {

		// -(UIImage *)mp_applyLightEffect;
		[Export ("mp_applyLightEffect")]
		UIImage Mp_applyLightEffect ();

		// -(UIImage *)mp_applyExtraLightEffect;
		[Export ("mp_applyExtraLightEffect")]
		UIImage Mp_applyExtraLightEffect ();

		// -(UIImage *)mp_applyDarkEffect;
		[Export ("mp_applyDarkEffect")]
		UIImage Mp_applyDarkEffect ();

		// -(UIImage *)mp_applyTintEffectWithColor:(UIColor *)tintColor;
		[Export ("mp_applyTintEffectWithColor:")]
		UIImage Mp_applyTintEffectWithColor (UIColor tintColor);

		// -(UIImage *)mp_applyBlurWithRadius:(CGFloat)blurRadius tintColor:(UIColor *)tintColor saturationDeltaFactor:(CGFloat)saturationDeltaFactor maskImage:(UIImage *)maskImage;
		[Export ("mp_applyBlurWithRadius:tintColor:saturationDeltaFactor:maskImage:")]
		UIImage Mp_applyBlurWithRadius (nfloat blurRadius, UIColor tintColor, nfloat saturationDeltaFactor, UIImage maskImage);
	}
	*/
}

