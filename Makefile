XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_ROOT=./MixpanelStaticLibrary
PROJECT=$(PROJECT_ROOT)/Mixpanel.xcodeproj
TARGET=Mixpanel

all: libMixpanel.a
	xbuild

libMixpanel-i386.a:
	    $(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
		    -mv $(PROJECT_ROOT)/build/Release-iphonesimulator/lib$(TARGET).a $@

libMixpanel-armv7.a:
	    $(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
		    -mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libMixpanel-arm64.a:
	    $(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch arm64 -configuration Release clean build
		    -mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libMixpanel.a: libMixpanel-i386.a libMixpanel-armv7.a libMixpanel-arm64.a
	    lipo -create -output $@ $^
		-cp $@ ./MixpanelBindings/
		-cp $@ ./MixpanelBindingsClassic/

clean:
	    -rm -f *.a *.dll
