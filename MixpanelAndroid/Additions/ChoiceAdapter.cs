using System;
using Android.Runtime;
namespace Mixpanel.Android.Surveys {

	public partial class CardCarouselLayout : global::Android.Views.ViewGroup {

		public partial class ChoiceAdapter : global::Java.Lang.Object, global::Android.Widget.IListAdapter {

			static Delegate cb_getItem_I;
			static Delegate GetGetItem_IHandler ()
			{
				if (cb_getItem_I == null)
					cb_getItem_I = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, IntPtr>) n_GetItem_I);
				return cb_getItem_I;
			}

			static IntPtr n_GetItem_I (IntPtr jnienv, IntPtr native__this, int p0)
			{
				global::Mixpanel.Android.Surveys.CardCarouselLayout.ChoiceAdapter __this = global::Java.Lang.Object.GetObject<global::Mixpanel.Android.Surveys.CardCarouselLayout.ChoiceAdapter> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.NewString (__this.GetItem (p0).ToString());
			}

			static IntPtr id_getItem_I;
			public virtual global::Java.Lang.Object GetItem (int p0)
			{
				if (id_getItem_I == IntPtr.Zero)
					id_getItem_I = JNIEnv.GetMethodID (class_ref, "getItem", "(I)Ljava/lang/String;");

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod  (Handle, id_getItem_I, new JValue (p0)), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getItem", "(I)Ljava/lang/String;"), new JValue (p0)), JniHandleOwnership.TransferLocalRef);
			}
		}
	}
}

