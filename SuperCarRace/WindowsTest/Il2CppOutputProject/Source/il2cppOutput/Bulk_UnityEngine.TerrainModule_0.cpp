﻿#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <cstring>
#include <string.h>
#include <stdio.h>
#include <cmath>
#include <limits>
#include <assert.h>
#include <stdint.h>

#include "il2cpp-class-internals.h"
#include "codegen/il2cpp-codegen.h"
#include "il2cpp-object-internals.h"


// UnityEngine.Terrain
struct Terrain_t3055443660;
// UnityEngine.Behaviour
struct Behaviour_t1437897464;
// UnityEngine.TerrainData
struct TerrainData_t657004131;
// UnityEngine.Object
struct Object_t631007953;
// System.Single[0...,0...,0...]
struct SingleU5B0___U2C0___U2C0___U5D_t1444911253;
// System.ArgumentException
struct ArgumentException_t132251570;
// System.String
struct String_t;
// System.Collections.IDictionary
struct IDictionary_t1363984059;
// System.Runtime.Serialization.SafeSerializationManager
struct SafeSerializationManager_t2481557153;
// System.Diagnostics.StackTrace[]
struct StackTraceU5BU5D_t1169129676;
// System.IntPtr[]
struct IntPtrU5BU5D_t4013366056;
// System.Void
struct Void_t1185182177;
// System.Char[]
struct CharU5BU5D_t3528271667;

extern RuntimeClass* Object_t631007953_il2cpp_TypeInfo_var;
extern RuntimeClass* TerrainData_t657004131_il2cpp_TypeInfo_var;
extern const uint32_t TerrainData__ctor_m1675272790_MetadataUsageId;
extern RuntimeClass* ArgumentException_t132251570_il2cpp_TypeInfo_var;
extern String_t* _stringLiteral3361472150;
extern const uint32_t TerrainData_GetAlphamaps_m3939888263_MetadataUsageId;
extern const uint32_t TerrainData__cctor_m2936165929_MetadataUsageId;
struct Exception_t_marshaled_pinvoke;
struct Exception_t_marshaled_com;

struct SingleU5B0___U2C0___U2C0___U5D_t1444911253;


#ifndef U3CMODULEU3E_T692745544_H
#define U3CMODULEU3E_T692745544_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct  U3CModuleU3E_t692745544 
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // U3CMODULEU3E_T692745544_H
#ifndef RUNTIMEOBJECT_H
#define RUNTIMEOBJECT_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Object

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // RUNTIMEOBJECT_H
#ifndef EXCEPTION_T_H
#define EXCEPTION_T_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Exception
struct  Exception_t  : public RuntimeObject
{
public:
	// System.String System.Exception::_className
	String_t* ____className_1;
	// System.String System.Exception::_message
	String_t* ____message_2;
	// System.Collections.IDictionary System.Exception::_data
	RuntimeObject* ____data_3;
	// System.Exception System.Exception::_innerException
	Exception_t * ____innerException_4;
	// System.String System.Exception::_helpURL
	String_t* ____helpURL_5;
	// System.Object System.Exception::_stackTrace
	RuntimeObject * ____stackTrace_6;
	// System.String System.Exception::_stackTraceString
	String_t* ____stackTraceString_7;
	// System.String System.Exception::_remoteStackTraceString
	String_t* ____remoteStackTraceString_8;
	// System.Int32 System.Exception::_remoteStackIndex
	int32_t ____remoteStackIndex_9;
	// System.Object System.Exception::_dynamicMethods
	RuntimeObject * ____dynamicMethods_10;
	// System.Int32 System.Exception::_HResult
	int32_t ____HResult_11;
	// System.String System.Exception::_source
	String_t* ____source_12;
	// System.Runtime.Serialization.SafeSerializationManager System.Exception::_safeSerializationManager
	SafeSerializationManager_t2481557153 * ____safeSerializationManager_13;
	// System.Diagnostics.StackTrace[] System.Exception::captured_traces
	StackTraceU5BU5D_t1169129676* ___captured_traces_14;
	// System.IntPtr[] System.Exception::native_trace_ips
	IntPtrU5BU5D_t4013366056* ___native_trace_ips_15;

public:
	inline static int32_t get_offset_of__className_1() { return static_cast<int32_t>(offsetof(Exception_t, ____className_1)); }
	inline String_t* get__className_1() const { return ____className_1; }
	inline String_t** get_address_of__className_1() { return &____className_1; }
	inline void set__className_1(String_t* value)
	{
		____className_1 = value;
		Il2CppCodeGenWriteBarrier((&____className_1), value);
	}

	inline static int32_t get_offset_of__message_2() { return static_cast<int32_t>(offsetof(Exception_t, ____message_2)); }
	inline String_t* get__message_2() const { return ____message_2; }
	inline String_t** get_address_of__message_2() { return &____message_2; }
	inline void set__message_2(String_t* value)
	{
		____message_2 = value;
		Il2CppCodeGenWriteBarrier((&____message_2), value);
	}

	inline static int32_t get_offset_of__data_3() { return static_cast<int32_t>(offsetof(Exception_t, ____data_3)); }
	inline RuntimeObject* get__data_3() const { return ____data_3; }
	inline RuntimeObject** get_address_of__data_3() { return &____data_3; }
	inline void set__data_3(RuntimeObject* value)
	{
		____data_3 = value;
		Il2CppCodeGenWriteBarrier((&____data_3), value);
	}

	inline static int32_t get_offset_of__innerException_4() { return static_cast<int32_t>(offsetof(Exception_t, ____innerException_4)); }
	inline Exception_t * get__innerException_4() const { return ____innerException_4; }
	inline Exception_t ** get_address_of__innerException_4() { return &____innerException_4; }
	inline void set__innerException_4(Exception_t * value)
	{
		____innerException_4 = value;
		Il2CppCodeGenWriteBarrier((&____innerException_4), value);
	}

	inline static int32_t get_offset_of__helpURL_5() { return static_cast<int32_t>(offsetof(Exception_t, ____helpURL_5)); }
	inline String_t* get__helpURL_5() const { return ____helpURL_5; }
	inline String_t** get_address_of__helpURL_5() { return &____helpURL_5; }
	inline void set__helpURL_5(String_t* value)
	{
		____helpURL_5 = value;
		Il2CppCodeGenWriteBarrier((&____helpURL_5), value);
	}

	inline static int32_t get_offset_of__stackTrace_6() { return static_cast<int32_t>(offsetof(Exception_t, ____stackTrace_6)); }
	inline RuntimeObject * get__stackTrace_6() const { return ____stackTrace_6; }
	inline RuntimeObject ** get_address_of__stackTrace_6() { return &____stackTrace_6; }
	inline void set__stackTrace_6(RuntimeObject * value)
	{
		____stackTrace_6 = value;
		Il2CppCodeGenWriteBarrier((&____stackTrace_6), value);
	}

	inline static int32_t get_offset_of__stackTraceString_7() { return static_cast<int32_t>(offsetof(Exception_t, ____stackTraceString_7)); }
	inline String_t* get__stackTraceString_7() const { return ____stackTraceString_7; }
	inline String_t** get_address_of__stackTraceString_7() { return &____stackTraceString_7; }
	inline void set__stackTraceString_7(String_t* value)
	{
		____stackTraceString_7 = value;
		Il2CppCodeGenWriteBarrier((&____stackTraceString_7), value);
	}

	inline static int32_t get_offset_of__remoteStackTraceString_8() { return static_cast<int32_t>(offsetof(Exception_t, ____remoteStackTraceString_8)); }
	inline String_t* get__remoteStackTraceString_8() const { return ____remoteStackTraceString_8; }
	inline String_t** get_address_of__remoteStackTraceString_8() { return &____remoteStackTraceString_8; }
	inline void set__remoteStackTraceString_8(String_t* value)
	{
		____remoteStackTraceString_8 = value;
		Il2CppCodeGenWriteBarrier((&____remoteStackTraceString_8), value);
	}

	inline static int32_t get_offset_of__remoteStackIndex_9() { return static_cast<int32_t>(offsetof(Exception_t, ____remoteStackIndex_9)); }
	inline int32_t get__remoteStackIndex_9() const { return ____remoteStackIndex_9; }
	inline int32_t* get_address_of__remoteStackIndex_9() { return &____remoteStackIndex_9; }
	inline void set__remoteStackIndex_9(int32_t value)
	{
		____remoteStackIndex_9 = value;
	}

	inline static int32_t get_offset_of__dynamicMethods_10() { return static_cast<int32_t>(offsetof(Exception_t, ____dynamicMethods_10)); }
	inline RuntimeObject * get__dynamicMethods_10() const { return ____dynamicMethods_10; }
	inline RuntimeObject ** get_address_of__dynamicMethods_10() { return &____dynamicMethods_10; }
	inline void set__dynamicMethods_10(RuntimeObject * value)
	{
		____dynamicMethods_10 = value;
		Il2CppCodeGenWriteBarrier((&____dynamicMethods_10), value);
	}

	inline static int32_t get_offset_of__HResult_11() { return static_cast<int32_t>(offsetof(Exception_t, ____HResult_11)); }
	inline int32_t get__HResult_11() const { return ____HResult_11; }
	inline int32_t* get_address_of__HResult_11() { return &____HResult_11; }
	inline void set__HResult_11(int32_t value)
	{
		____HResult_11 = value;
	}

	inline static int32_t get_offset_of__source_12() { return static_cast<int32_t>(offsetof(Exception_t, ____source_12)); }
	inline String_t* get__source_12() const { return ____source_12; }
	inline String_t** get_address_of__source_12() { return &____source_12; }
	inline void set__source_12(String_t* value)
	{
		____source_12 = value;
		Il2CppCodeGenWriteBarrier((&____source_12), value);
	}

	inline static int32_t get_offset_of__safeSerializationManager_13() { return static_cast<int32_t>(offsetof(Exception_t, ____safeSerializationManager_13)); }
	inline SafeSerializationManager_t2481557153 * get__safeSerializationManager_13() const { return ____safeSerializationManager_13; }
	inline SafeSerializationManager_t2481557153 ** get_address_of__safeSerializationManager_13() { return &____safeSerializationManager_13; }
	inline void set__safeSerializationManager_13(SafeSerializationManager_t2481557153 * value)
	{
		____safeSerializationManager_13 = value;
		Il2CppCodeGenWriteBarrier((&____safeSerializationManager_13), value);
	}

	inline static int32_t get_offset_of_captured_traces_14() { return static_cast<int32_t>(offsetof(Exception_t, ___captured_traces_14)); }
	inline StackTraceU5BU5D_t1169129676* get_captured_traces_14() const { return ___captured_traces_14; }
	inline StackTraceU5BU5D_t1169129676** get_address_of_captured_traces_14() { return &___captured_traces_14; }
	inline void set_captured_traces_14(StackTraceU5BU5D_t1169129676* value)
	{
		___captured_traces_14 = value;
		Il2CppCodeGenWriteBarrier((&___captured_traces_14), value);
	}

	inline static int32_t get_offset_of_native_trace_ips_15() { return static_cast<int32_t>(offsetof(Exception_t, ___native_trace_ips_15)); }
	inline IntPtrU5BU5D_t4013366056* get_native_trace_ips_15() const { return ___native_trace_ips_15; }
	inline IntPtrU5BU5D_t4013366056** get_address_of_native_trace_ips_15() { return &___native_trace_ips_15; }
	inline void set_native_trace_ips_15(IntPtrU5BU5D_t4013366056* value)
	{
		___native_trace_ips_15 = value;
		Il2CppCodeGenWriteBarrier((&___native_trace_ips_15), value);
	}
};

struct Exception_t_StaticFields
{
public:
	// System.Object System.Exception::s_EDILock
	RuntimeObject * ___s_EDILock_0;

public:
	inline static int32_t get_offset_of_s_EDILock_0() { return static_cast<int32_t>(offsetof(Exception_t_StaticFields, ___s_EDILock_0)); }
	inline RuntimeObject * get_s_EDILock_0() const { return ___s_EDILock_0; }
	inline RuntimeObject ** get_address_of_s_EDILock_0() { return &___s_EDILock_0; }
	inline void set_s_EDILock_0(RuntimeObject * value)
	{
		___s_EDILock_0 = value;
		Il2CppCodeGenWriteBarrier((&___s_EDILock_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.Exception
struct Exception_t_marshaled_pinvoke
{
	char* ____className_1;
	char* ____message_2;
	RuntimeObject* ____data_3;
	Exception_t_marshaled_pinvoke* ____innerException_4;
	char* ____helpURL_5;
	Il2CppIUnknown* ____stackTrace_6;
	char* ____stackTraceString_7;
	char* ____remoteStackTraceString_8;
	int32_t ____remoteStackIndex_9;
	Il2CppIUnknown* ____dynamicMethods_10;
	int32_t ____HResult_11;
	char* ____source_12;
	SafeSerializationManager_t2481557153 * ____safeSerializationManager_13;
	StackTraceU5BU5D_t1169129676* ___captured_traces_14;
	intptr_t* ___native_trace_ips_15;
};
// Native definition for COM marshalling of System.Exception
struct Exception_t_marshaled_com
{
	Il2CppChar* ____className_1;
	Il2CppChar* ____message_2;
	RuntimeObject* ____data_3;
	Exception_t_marshaled_com* ____innerException_4;
	Il2CppChar* ____helpURL_5;
	Il2CppIUnknown* ____stackTrace_6;
	Il2CppChar* ____stackTraceString_7;
	Il2CppChar* ____remoteStackTraceString_8;
	int32_t ____remoteStackIndex_9;
	Il2CppIUnknown* ____dynamicMethods_10;
	int32_t ____HResult_11;
	Il2CppChar* ____source_12;
	SafeSerializationManager_t2481557153 * ____safeSerializationManager_13;
	StackTraceU5BU5D_t1169129676* ___captured_traces_14;
	intptr_t* ___native_trace_ips_15;
};
#endif // EXCEPTION_T_H
#ifndef STRING_T_H
#define STRING_T_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.String
struct  String_t  : public RuntimeObject
{
public:
	// System.Int32 System.String::m_stringLength
	int32_t ___m_stringLength_0;
	// System.Char System.String::m_firstChar
	Il2CppChar ___m_firstChar_1;

public:
	inline static int32_t get_offset_of_m_stringLength_0() { return static_cast<int32_t>(offsetof(String_t, ___m_stringLength_0)); }
	inline int32_t get_m_stringLength_0() const { return ___m_stringLength_0; }
	inline int32_t* get_address_of_m_stringLength_0() { return &___m_stringLength_0; }
	inline void set_m_stringLength_0(int32_t value)
	{
		___m_stringLength_0 = value;
	}

	inline static int32_t get_offset_of_m_firstChar_1() { return static_cast<int32_t>(offsetof(String_t, ___m_firstChar_1)); }
	inline Il2CppChar get_m_firstChar_1() const { return ___m_firstChar_1; }
	inline Il2CppChar* get_address_of_m_firstChar_1() { return &___m_firstChar_1; }
	inline void set_m_firstChar_1(Il2CppChar value)
	{
		___m_firstChar_1 = value;
	}
};

struct String_t_StaticFields
{
public:
	// System.String System.String::Empty
	String_t* ___Empty_5;

public:
	inline static int32_t get_offset_of_Empty_5() { return static_cast<int32_t>(offsetof(String_t_StaticFields, ___Empty_5)); }
	inline String_t* get_Empty_5() const { return ___Empty_5; }
	inline String_t** get_address_of_Empty_5() { return &___Empty_5; }
	inline void set_Empty_5(String_t* value)
	{
		___Empty_5 = value;
		Il2CppCodeGenWriteBarrier((&___Empty_5), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // STRING_T_H
#ifndef VALUETYPE_T3640485471_H
#define VALUETYPE_T3640485471_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ValueType
struct  ValueType_t3640485471  : public RuntimeObject
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.ValueType
struct ValueType_t3640485471_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.ValueType
struct ValueType_t3640485471_marshaled_com
{
};
#endif // VALUETYPE_T3640485471_H
struct Il2CppArrayBounds;
#ifndef RUNTIMEARRAY_H
#define RUNTIMEARRAY_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Array

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // RUNTIMEARRAY_H
#ifndef SINGLE_T1397266774_H
#define SINGLE_T1397266774_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Single
struct  Single_t1397266774 
{
public:
	// System.Single System.Single::m_value
	float ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Single_t1397266774, ___m_value_0)); }
	inline float get_m_value_0() const { return ___m_value_0; }
	inline float* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(float value)
	{
		___m_value_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SINGLE_T1397266774_H
#ifndef VOID_T1185182177_H
#define VOID_T1185182177_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Void
struct  Void_t1185182177 
{
public:
	union
	{
		struct
		{
		};
		uint8_t Void_t1185182177__padding[1];
	};

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // VOID_T1185182177_H
#ifndef VECTOR3_T3722313464_H
#define VECTOR3_T3722313464_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Vector3
struct  Vector3_t3722313464 
{
public:
	// System.Single UnityEngine.Vector3::x
	float ___x_1;
	// System.Single UnityEngine.Vector3::y
	float ___y_2;
	// System.Single UnityEngine.Vector3::z
	float ___z_3;

public:
	inline static int32_t get_offset_of_x_1() { return static_cast<int32_t>(offsetof(Vector3_t3722313464, ___x_1)); }
	inline float get_x_1() const { return ___x_1; }
	inline float* get_address_of_x_1() { return &___x_1; }
	inline void set_x_1(float value)
	{
		___x_1 = value;
	}

	inline static int32_t get_offset_of_y_2() { return static_cast<int32_t>(offsetof(Vector3_t3722313464, ___y_2)); }
	inline float get_y_2() const { return ___y_2; }
	inline float* get_address_of_y_2() { return &___y_2; }
	inline void set_y_2(float value)
	{
		___y_2 = value;
	}

	inline static int32_t get_offset_of_z_3() { return static_cast<int32_t>(offsetof(Vector3_t3722313464, ___z_3)); }
	inline float get_z_3() const { return ___z_3; }
	inline float* get_address_of_z_3() { return &___z_3; }
	inline void set_z_3(float value)
	{
		___z_3 = value;
	}
};

struct Vector3_t3722313464_StaticFields
{
public:
	// UnityEngine.Vector3 UnityEngine.Vector3::zeroVector
	Vector3_t3722313464  ___zeroVector_4;
	// UnityEngine.Vector3 UnityEngine.Vector3::oneVector
	Vector3_t3722313464  ___oneVector_5;
	// UnityEngine.Vector3 UnityEngine.Vector3::upVector
	Vector3_t3722313464  ___upVector_6;
	// UnityEngine.Vector3 UnityEngine.Vector3::downVector
	Vector3_t3722313464  ___downVector_7;
	// UnityEngine.Vector3 UnityEngine.Vector3::leftVector
	Vector3_t3722313464  ___leftVector_8;
	// UnityEngine.Vector3 UnityEngine.Vector3::rightVector
	Vector3_t3722313464  ___rightVector_9;
	// UnityEngine.Vector3 UnityEngine.Vector3::forwardVector
	Vector3_t3722313464  ___forwardVector_10;
	// UnityEngine.Vector3 UnityEngine.Vector3::backVector
	Vector3_t3722313464  ___backVector_11;
	// UnityEngine.Vector3 UnityEngine.Vector3::positiveInfinityVector
	Vector3_t3722313464  ___positiveInfinityVector_12;
	// UnityEngine.Vector3 UnityEngine.Vector3::negativeInfinityVector
	Vector3_t3722313464  ___negativeInfinityVector_13;

public:
	inline static int32_t get_offset_of_zeroVector_4() { return static_cast<int32_t>(offsetof(Vector3_t3722313464_StaticFields, ___zeroVector_4)); }
	inline Vector3_t3722313464  get_zeroVector_4() const { return ___zeroVector_4; }
	inline Vector3_t3722313464 * get_address_of_zeroVector_4() { return &___zeroVector_4; }
	inline void set_zeroVector_4(Vector3_t3722313464  value)
	{
		___zeroVector_4 = value;
	}

	inline static int32_t get_offset_of_oneVector_5() { return static_cast<int32_t>(offsetof(Vector3_t3722313464_StaticFields, ___oneVector_5)); }
	inline Vector3_t3722313464  get_oneVector_5() const { return ___oneVector_5; }
	inline Vector3_t3722313464 * get_address_of_oneVector_5() { return &___oneVector_5; }
	inline void set_oneVector_5(Vector3_t3722313464  value)
	{
		___oneVector_5 = value;
	}

	inline static int32_t get_offset_of_upVector_6() { return static_cast<int32_t>(offsetof(Vector3_t3722313464_StaticFields, ___upVector_6)); }
	inline Vector3_t3722313464  get_upVector_6() const { return ___upVector_6; }
	inline Vector3_t3722313464 * get_address_of_upVector_6() { return &___upVector_6; }
	inline void set_upVector_6(Vector3_t3722313464  value)
	{
		___upVector_6 = value;
	}

	inline static int32_t get_offset_of_downVector_7() { return static_cast<int32_t>(offsetof(Vector3_t3722313464_StaticFields, ___downVector_7)); }
	inline Vector3_t3722313464  get_downVector_7() const { return ___downVector_7; }
	inline Vector3_t3722313464 * get_address_of_downVector_7() { return &___downVector_7; }
	inline void set_downVector_7(Vector3_t3722313464  value)
	{
		___downVector_7 = value;
	}

	inline static int32_t get_offset_of_leftVector_8() { return static_cast<int32_t>(offsetof(Vector3_t3722313464_StaticFields, ___leftVector_8)); }
	inline Vector3_t3722313464  get_leftVector_8() const { return ___leftVector_8; }
	inline Vector3_t3722313464 * get_address_of_leftVector_8() { return &___leftVector_8; }
	inline void set_leftVector_8(Vector3_t3722313464  value)
	{
		___leftVector_8 = value;
	}

	inline static int32_t get_offset_of_rightVector_9() { return static_cast<int32_t>(offsetof(Vector3_t3722313464_StaticFields, ___rightVector_9)); }
	inline Vector3_t3722313464  get_rightVector_9() const { return ___rightVector_9; }
	inline Vector3_t3722313464 * get_address_of_rightVector_9() { return &___rightVector_9; }
	inline void set_rightVector_9(Vector3_t3722313464  value)
	{
		___rightVector_9 = value;
	}

	inline static int32_t get_offset_of_forwardVector_10() { return static_cast<int32_t>(offsetof(Vector3_t3722313464_StaticFields, ___forwardVector_10)); }
	inline Vector3_t3722313464  get_forwardVector_10() const { return ___forwardVector_10; }
	inline Vector3_t3722313464 * get_address_of_forwardVector_10() { return &___forwardVector_10; }
	inline void set_forwardVector_10(Vector3_t3722313464  value)
	{
		___forwardVector_10 = value;
	}

	inline static int32_t get_offset_of_backVector_11() { return static_cast<int32_t>(offsetof(Vector3_t3722313464_StaticFields, ___backVector_11)); }
	inline Vector3_t3722313464  get_backVector_11() const { return ___backVector_11; }
	inline Vector3_t3722313464 * get_address_of_backVector_11() { return &___backVector_11; }
	inline void set_backVector_11(Vector3_t3722313464  value)
	{
		___backVector_11 = value;
	}

	inline static int32_t get_offset_of_positiveInfinityVector_12() { return static_cast<int32_t>(offsetof(Vector3_t3722313464_StaticFields, ___positiveInfinityVector_12)); }
	inline Vector3_t3722313464  get_positiveInfinityVector_12() const { return ___positiveInfinityVector_12; }
	inline Vector3_t3722313464 * get_address_of_positiveInfinityVector_12() { return &___positiveInfinityVector_12; }
	inline void set_positiveInfinityVector_12(Vector3_t3722313464  value)
	{
		___positiveInfinityVector_12 = value;
	}

	inline static int32_t get_offset_of_negativeInfinityVector_13() { return static_cast<int32_t>(offsetof(Vector3_t3722313464_StaticFields, ___negativeInfinityVector_13)); }
	inline Vector3_t3722313464  get_negativeInfinityVector_13() const { return ___negativeInfinityVector_13; }
	inline Vector3_t3722313464 * get_address_of_negativeInfinityVector_13() { return &___negativeInfinityVector_13; }
	inline void set_negativeInfinityVector_13(Vector3_t3722313464  value)
	{
		___negativeInfinityVector_13 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // VECTOR3_T3722313464_H
#ifndef INTPTR_T_H
#define INTPTR_T_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.IntPtr
struct  IntPtr_t 
{
public:
	// System.Void* System.IntPtr::m_value
	void* ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(IntPtr_t, ___m_value_0)); }
	inline void* get_m_value_0() const { return ___m_value_0; }
	inline void** get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(void* value)
	{
		___m_value_0 = value;
	}
};

struct IntPtr_t_StaticFields
{
public:
	// System.IntPtr System.IntPtr::Zero
	intptr_t ___Zero_1;

public:
	inline static int32_t get_offset_of_Zero_1() { return static_cast<int32_t>(offsetof(IntPtr_t_StaticFields, ___Zero_1)); }
	inline intptr_t get_Zero_1() const { return ___Zero_1; }
	inline intptr_t* get_address_of_Zero_1() { return &___Zero_1; }
	inline void set_Zero_1(intptr_t value)
	{
		___Zero_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // INTPTR_T_H
#ifndef SYSTEMEXCEPTION_T176217640_H
#define SYSTEMEXCEPTION_T176217640_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.SystemException
struct  SystemException_t176217640  : public Exception_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SYSTEMEXCEPTION_T176217640_H
#ifndef ENUM_T4135868527_H
#define ENUM_T4135868527_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Enum
struct  Enum_t4135868527  : public ValueType_t3640485471
{
public:

public:
};

struct Enum_t4135868527_StaticFields
{
public:
	// System.Char[] System.Enum::enumSeperatorCharArray
	CharU5BU5D_t3528271667* ___enumSeperatorCharArray_0;

public:
	inline static int32_t get_offset_of_enumSeperatorCharArray_0() { return static_cast<int32_t>(offsetof(Enum_t4135868527_StaticFields, ___enumSeperatorCharArray_0)); }
	inline CharU5BU5D_t3528271667* get_enumSeperatorCharArray_0() const { return ___enumSeperatorCharArray_0; }
	inline CharU5BU5D_t3528271667** get_address_of_enumSeperatorCharArray_0() { return &___enumSeperatorCharArray_0; }
	inline void set_enumSeperatorCharArray_0(CharU5BU5D_t3528271667* value)
	{
		___enumSeperatorCharArray_0 = value;
		Il2CppCodeGenWriteBarrier((&___enumSeperatorCharArray_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.Enum
struct Enum_t4135868527_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.Enum
struct Enum_t4135868527_marshaled_com
{
};
#endif // ENUM_T4135868527_H
#ifndef INT32_T2950945753_H
#define INT32_T2950945753_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Int32
struct  Int32_t2950945753 
{
public:
	// System.Int32 System.Int32::m_value
	int32_t ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Int32_t2950945753, ___m_value_0)); }
	inline int32_t get_m_value_0() const { return ___m_value_0; }
	inline int32_t* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(int32_t value)
	{
		___m_value_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // INT32_T2950945753_H
#ifndef OBJECT_T631007953_H
#define OBJECT_T631007953_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Object
struct  Object_t631007953  : public RuntimeObject
{
public:
	// System.IntPtr UnityEngine.Object::m_CachedPtr
	intptr_t ___m_CachedPtr_0;

public:
	inline static int32_t get_offset_of_m_CachedPtr_0() { return static_cast<int32_t>(offsetof(Object_t631007953, ___m_CachedPtr_0)); }
	inline intptr_t get_m_CachedPtr_0() const { return ___m_CachedPtr_0; }
	inline intptr_t* get_address_of_m_CachedPtr_0() { return &___m_CachedPtr_0; }
	inline void set_m_CachedPtr_0(intptr_t value)
	{
		___m_CachedPtr_0 = value;
	}
};

struct Object_t631007953_StaticFields
{
public:
	// System.Int32 UnityEngine.Object::OffsetOfInstanceIDInCPlusPlusObject
	int32_t ___OffsetOfInstanceIDInCPlusPlusObject_1;

public:
	inline static int32_t get_offset_of_OffsetOfInstanceIDInCPlusPlusObject_1() { return static_cast<int32_t>(offsetof(Object_t631007953_StaticFields, ___OffsetOfInstanceIDInCPlusPlusObject_1)); }
	inline int32_t get_OffsetOfInstanceIDInCPlusPlusObject_1() const { return ___OffsetOfInstanceIDInCPlusPlusObject_1; }
	inline int32_t* get_address_of_OffsetOfInstanceIDInCPlusPlusObject_1() { return &___OffsetOfInstanceIDInCPlusPlusObject_1; }
	inline void set_OffsetOfInstanceIDInCPlusPlusObject_1(int32_t value)
	{
		___OffsetOfInstanceIDInCPlusPlusObject_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of UnityEngine.Object
struct Object_t631007953_marshaled_pinvoke
{
	intptr_t ___m_CachedPtr_0;
};
// Native definition for COM marshalling of UnityEngine.Object
struct Object_t631007953_marshaled_com
{
	intptr_t ___m_CachedPtr_0;
};
#endif // OBJECT_T631007953_H
#ifndef ARGUMENTEXCEPTION_T132251570_H
#define ARGUMENTEXCEPTION_T132251570_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ArgumentException
struct  ArgumentException_t132251570  : public SystemException_t176217640
{
public:
	// System.String System.ArgumentException::m_paramName
	String_t* ___m_paramName_16;

public:
	inline static int32_t get_offset_of_m_paramName_16() { return static_cast<int32_t>(offsetof(ArgumentException_t132251570, ___m_paramName_16)); }
	inline String_t* get_m_paramName_16() const { return ___m_paramName_16; }
	inline String_t** get_address_of_m_paramName_16() { return &___m_paramName_16; }
	inline void set_m_paramName_16(String_t* value)
	{
		___m_paramName_16 = value;
		Il2CppCodeGenWriteBarrier((&___m_paramName_16), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ARGUMENTEXCEPTION_T132251570_H
#ifndef BOUNDARYVALUETYPE_T1782311533_H
#define BOUNDARYVALUETYPE_T1782311533_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.TerrainData/BoundaryValueType
struct  BoundaryValueType_t1782311533 
{
public:
	// System.Int32 UnityEngine.TerrainData/BoundaryValueType::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(BoundaryValueType_t1782311533, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // BOUNDARYVALUETYPE_T1782311533_H
#ifndef TERRAINDATA_T657004131_H
#define TERRAINDATA_T657004131_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.TerrainData
struct  TerrainData_t657004131  : public Object_t631007953
{
public:

public:
};

struct TerrainData_t657004131_StaticFields
{
public:
	// System.Int32 UnityEngine.TerrainData::k_MaximumResolution
	int32_t ___k_MaximumResolution_2;
	// System.Int32 UnityEngine.TerrainData::k_MinimumDetailResolutionPerPatch
	int32_t ___k_MinimumDetailResolutionPerPatch_3;
	// System.Int32 UnityEngine.TerrainData::k_MaximumDetailResolutionPerPatch
	int32_t ___k_MaximumDetailResolutionPerPatch_4;
	// System.Int32 UnityEngine.TerrainData::k_MaximumDetailPatchCount
	int32_t ___k_MaximumDetailPatchCount_5;
	// System.Int32 UnityEngine.TerrainData::k_MinimumAlphamapResolution
	int32_t ___k_MinimumAlphamapResolution_6;
	// System.Int32 UnityEngine.TerrainData::k_MaximumAlphamapResolution
	int32_t ___k_MaximumAlphamapResolution_7;
	// System.Int32 UnityEngine.TerrainData::k_MinimumBaseMapResolution
	int32_t ___k_MinimumBaseMapResolution_8;
	// System.Int32 UnityEngine.TerrainData::k_MaximumBaseMapResolution
	int32_t ___k_MaximumBaseMapResolution_9;

public:
	inline static int32_t get_offset_of_k_MaximumResolution_2() { return static_cast<int32_t>(offsetof(TerrainData_t657004131_StaticFields, ___k_MaximumResolution_2)); }
	inline int32_t get_k_MaximumResolution_2() const { return ___k_MaximumResolution_2; }
	inline int32_t* get_address_of_k_MaximumResolution_2() { return &___k_MaximumResolution_2; }
	inline void set_k_MaximumResolution_2(int32_t value)
	{
		___k_MaximumResolution_2 = value;
	}

	inline static int32_t get_offset_of_k_MinimumDetailResolutionPerPatch_3() { return static_cast<int32_t>(offsetof(TerrainData_t657004131_StaticFields, ___k_MinimumDetailResolutionPerPatch_3)); }
	inline int32_t get_k_MinimumDetailResolutionPerPatch_3() const { return ___k_MinimumDetailResolutionPerPatch_3; }
	inline int32_t* get_address_of_k_MinimumDetailResolutionPerPatch_3() { return &___k_MinimumDetailResolutionPerPatch_3; }
	inline void set_k_MinimumDetailResolutionPerPatch_3(int32_t value)
	{
		___k_MinimumDetailResolutionPerPatch_3 = value;
	}

	inline static int32_t get_offset_of_k_MaximumDetailResolutionPerPatch_4() { return static_cast<int32_t>(offsetof(TerrainData_t657004131_StaticFields, ___k_MaximumDetailResolutionPerPatch_4)); }
	inline int32_t get_k_MaximumDetailResolutionPerPatch_4() const { return ___k_MaximumDetailResolutionPerPatch_4; }
	inline int32_t* get_address_of_k_MaximumDetailResolutionPerPatch_4() { return &___k_MaximumDetailResolutionPerPatch_4; }
	inline void set_k_MaximumDetailResolutionPerPatch_4(int32_t value)
	{
		___k_MaximumDetailResolutionPerPatch_4 = value;
	}

	inline static int32_t get_offset_of_k_MaximumDetailPatchCount_5() { return static_cast<int32_t>(offsetof(TerrainData_t657004131_StaticFields, ___k_MaximumDetailPatchCount_5)); }
	inline int32_t get_k_MaximumDetailPatchCount_5() const { return ___k_MaximumDetailPatchCount_5; }
	inline int32_t* get_address_of_k_MaximumDetailPatchCount_5() { return &___k_MaximumDetailPatchCount_5; }
	inline void set_k_MaximumDetailPatchCount_5(int32_t value)
	{
		___k_MaximumDetailPatchCount_5 = value;
	}

	inline static int32_t get_offset_of_k_MinimumAlphamapResolution_6() { return static_cast<int32_t>(offsetof(TerrainData_t657004131_StaticFields, ___k_MinimumAlphamapResolution_6)); }
	inline int32_t get_k_MinimumAlphamapResolution_6() const { return ___k_MinimumAlphamapResolution_6; }
	inline int32_t* get_address_of_k_MinimumAlphamapResolution_6() { return &___k_MinimumAlphamapResolution_6; }
	inline void set_k_MinimumAlphamapResolution_6(int32_t value)
	{
		___k_MinimumAlphamapResolution_6 = value;
	}

	inline static int32_t get_offset_of_k_MaximumAlphamapResolution_7() { return static_cast<int32_t>(offsetof(TerrainData_t657004131_StaticFields, ___k_MaximumAlphamapResolution_7)); }
	inline int32_t get_k_MaximumAlphamapResolution_7() const { return ___k_MaximumAlphamapResolution_7; }
	inline int32_t* get_address_of_k_MaximumAlphamapResolution_7() { return &___k_MaximumAlphamapResolution_7; }
	inline void set_k_MaximumAlphamapResolution_7(int32_t value)
	{
		___k_MaximumAlphamapResolution_7 = value;
	}

	inline static int32_t get_offset_of_k_MinimumBaseMapResolution_8() { return static_cast<int32_t>(offsetof(TerrainData_t657004131_StaticFields, ___k_MinimumBaseMapResolution_8)); }
	inline int32_t get_k_MinimumBaseMapResolution_8() const { return ___k_MinimumBaseMapResolution_8; }
	inline int32_t* get_address_of_k_MinimumBaseMapResolution_8() { return &___k_MinimumBaseMapResolution_8; }
	inline void set_k_MinimumBaseMapResolution_8(int32_t value)
	{
		___k_MinimumBaseMapResolution_8 = value;
	}

	inline static int32_t get_offset_of_k_MaximumBaseMapResolution_9() { return static_cast<int32_t>(offsetof(TerrainData_t657004131_StaticFields, ___k_MaximumBaseMapResolution_9)); }
	inline int32_t get_k_MaximumBaseMapResolution_9() const { return ___k_MaximumBaseMapResolution_9; }
	inline int32_t* get_address_of_k_MaximumBaseMapResolution_9() { return &___k_MaximumBaseMapResolution_9; }
	inline void set_k_MaximumBaseMapResolution_9(int32_t value)
	{
		___k_MaximumBaseMapResolution_9 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TERRAINDATA_T657004131_H
#ifndef COMPONENT_T1923634451_H
#define COMPONENT_T1923634451_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Component
struct  Component_t1923634451  : public Object_t631007953
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // COMPONENT_T1923634451_H
#ifndef BEHAVIOUR_T1437897464_H
#define BEHAVIOUR_T1437897464_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Behaviour
struct  Behaviour_t1437897464  : public Component_t1923634451
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // BEHAVIOUR_T1437897464_H
#ifndef TERRAIN_T3055443660_H
#define TERRAIN_T3055443660_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Terrain
struct  Terrain_t3055443660  : public Behaviour_t1437897464
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TERRAIN_T3055443660_H
// System.Single[0...,0...,0...]
struct SingleU5B0___U2C0___U2C0___U5D_t1444911253  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) float m_Items[1];

public:
	inline float GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline float* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, float value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline float GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline float* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, float value)
	{
		m_Items[index] = value;
	}
	inline float GetAt(il2cpp_array_size_t i, il2cpp_array_size_t j, il2cpp_array_size_t k) const
	{
		il2cpp_array_size_t iBound = bounds[0].length;
		IL2CPP_ARRAY_BOUNDS_CHECK(i, iBound);
		il2cpp_array_size_t jBound = bounds[1].length;
		IL2CPP_ARRAY_BOUNDS_CHECK(j, jBound);
		il2cpp_array_size_t kBound = bounds[2].length;
		IL2CPP_ARRAY_BOUNDS_CHECK(k, kBound);

		il2cpp_array_size_t index = (i * jBound + j) * kBound + k;
		return m_Items[index];
	}
	inline float* GetAddressAt(il2cpp_array_size_t i, il2cpp_array_size_t j, il2cpp_array_size_t k)
	{
		il2cpp_array_size_t iBound = bounds[0].length;
		IL2CPP_ARRAY_BOUNDS_CHECK(i, iBound);
		il2cpp_array_size_t jBound = bounds[1].length;
		IL2CPP_ARRAY_BOUNDS_CHECK(j, jBound);
		il2cpp_array_size_t kBound = bounds[2].length;
		IL2CPP_ARRAY_BOUNDS_CHECK(k, kBound);

		il2cpp_array_size_t index = (i * jBound + j) * kBound + k;
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t i, il2cpp_array_size_t j, il2cpp_array_size_t k, float value)
	{
		il2cpp_array_size_t iBound = bounds[0].length;
		IL2CPP_ARRAY_BOUNDS_CHECK(i, iBound);
		il2cpp_array_size_t jBound = bounds[1].length;
		IL2CPP_ARRAY_BOUNDS_CHECK(j, jBound);
		il2cpp_array_size_t kBound = bounds[2].length;
		IL2CPP_ARRAY_BOUNDS_CHECK(k, kBound);

		il2cpp_array_size_t index = (i * jBound + j) * kBound + k;
		m_Items[index] = value;
	}
	inline float GetAtUnchecked(il2cpp_array_size_t i, il2cpp_array_size_t j, il2cpp_array_size_t k) const
	{
		il2cpp_array_size_t jBound = bounds[1].length;
		il2cpp_array_size_t kBound = bounds[2].length;

		il2cpp_array_size_t index = (i * jBound + j) * kBound + k;
		return m_Items[index];
	}
	inline float* GetAddressAtUnchecked(il2cpp_array_size_t i, il2cpp_array_size_t j, il2cpp_array_size_t k)
	{
		il2cpp_array_size_t jBound = bounds[1].length;
		il2cpp_array_size_t kBound = bounds[2].length;

		il2cpp_array_size_t index = (i * jBound + j) * kBound + k;
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t i, il2cpp_array_size_t j, il2cpp_array_size_t k, float value)
	{
		il2cpp_array_size_t jBound = bounds[1].length;
		il2cpp_array_size_t kBound = bounds[2].length;

		il2cpp_array_size_t index = (i * jBound + j) * kBound + k;
		m_Items[index] = value;
	}
};



// System.Void UnityEngine.Behaviour::.ctor()
extern "C"  void Behaviour__ctor_m346897018 (Behaviour_t1437897464 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.Object::.ctor()
extern "C"  void Object__ctor_m1087895580 (Object_t631007953 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.TerrainData::Internal_Create(UnityEngine.TerrainData)
extern "C"  void TerrainData_Internal_Create_m1566437197 (RuntimeObject * __this /* static, unused */, TerrainData_t657004131 * ___terrainData0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.TerrainData::get_size_Injected(UnityEngine.Vector3&)
extern "C"  void TerrainData_get_size_Injected_m1617926404 (TerrainData_t657004131 * __this, Vector3_t3722313464 * ___ret0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void System.ArgumentException::.ctor(System.String)
extern "C"  void ArgumentException__ctor_m1312628991 (ArgumentException_t132251570 * __this, String_t* p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Single[0...,0...,0...] UnityEngine.TerrainData::Internal_GetAlphamaps(System.Int32,System.Int32,System.Int32,System.Int32)
extern "C"  SingleU5B0___U2C0___U2C0___U5D_t1444911253* TerrainData_Internal_GetAlphamaps_m346749885 (TerrainData_t657004131 * __this, int32_t ___x0, int32_t ___y1, int32_t ___width2, int32_t ___height3, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Int32 UnityEngine.TerrainData::get_Internal_alphamapResolution()
extern "C"  int32_t TerrainData_get_Internal_alphamapResolution_m3110480181 (TerrainData_t657004131 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Int32 UnityEngine.TerrainData::get_alphamapResolution()
extern "C"  int32_t TerrainData_get_alphamapResolution_m1154394489 (TerrainData_t657004131 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Int32 UnityEngine.TerrainData::GetBoundaryValue(UnityEngine.TerrainData/BoundaryValueType)
extern "C"  int32_t TerrainData_GetBoundaryValue_m1103633233 (RuntimeObject * __this /* static, unused */, int32_t ___type0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void UnityEngine.Terrain::.ctor()
extern "C"  void Terrain__ctor_m2653169332 (Terrain_t3055443660 * __this, const RuntimeMethod* method)
{
	{
		Behaviour__ctor_m346897018(__this, /*hidden argument*/NULL);
		return;
	}
}
// UnityEngine.TerrainData UnityEngine.Terrain::get_terrainData()
extern "C"  TerrainData_t657004131 * Terrain_get_terrainData_m2711583617 (Terrain_t3055443660 * __this, const RuntimeMethod* method)
{
	typedef TerrainData_t657004131 * (*Terrain_get_terrainData_m2711583617_ftn) (Terrain_t3055443660 *);
	static Terrain_get_terrainData_m2711583617_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_terrainData_m2711583617_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_terrainData()");
	TerrainData_t657004131 * retVal = _il2cpp_icall_func(__this);
	return retVal;
}
// UnityEngine.Terrain UnityEngine.Terrain::get_activeTerrain()
extern "C"  Terrain_t3055443660 * Terrain_get_activeTerrain_m2378246603 (RuntimeObject * __this /* static, unused */, const RuntimeMethod* method)
{
	typedef Terrain_t3055443660 * (*Terrain_get_activeTerrain_m2378246603_ftn) ();
	static Terrain_get_activeTerrain_m2378246603_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Terrain_get_activeTerrain_m2378246603_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Terrain::get_activeTerrain()");
	Terrain_t3055443660 * retVal = _il2cpp_icall_func();
	return retVal;
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void UnityEngine.TerrainData::.ctor()
extern "C"  void TerrainData__ctor_m1675272790 (TerrainData_t657004131 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (TerrainData__ctor_m1675272790_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(Object_t631007953_il2cpp_TypeInfo_var);
		Object__ctor_m1087895580(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(TerrainData_t657004131_il2cpp_TypeInfo_var);
		TerrainData_Internal_Create_m1566437197(NULL /*static, unused*/, __this, /*hidden argument*/NULL);
		return;
	}
}
// System.Int32 UnityEngine.TerrainData::GetBoundaryValue(UnityEngine.TerrainData/BoundaryValueType)
extern "C"  int32_t TerrainData_GetBoundaryValue_m1103633233 (RuntimeObject * __this /* static, unused */, int32_t ___type0, const RuntimeMethod* method)
{
	typedef int32_t (*TerrainData_GetBoundaryValue_m1103633233_ftn) (int32_t);
	static TerrainData_GetBoundaryValue_m1103633233_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_GetBoundaryValue_m1103633233_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::GetBoundaryValue(UnityEngine.TerrainData/BoundaryValueType)");
	int32_t retVal = _il2cpp_icall_func(___type0);
	return retVal;
}
// System.Void UnityEngine.TerrainData::Internal_Create(UnityEngine.TerrainData)
extern "C"  void TerrainData_Internal_Create_m1566437197 (RuntimeObject * __this /* static, unused */, TerrainData_t657004131 * ___terrainData0, const RuntimeMethod* method)
{
	typedef void (*TerrainData_Internal_Create_m1566437197_ftn) (TerrainData_t657004131 *);
	static TerrainData_Internal_Create_m1566437197_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_Internal_Create_m1566437197_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::Internal_Create(UnityEngine.TerrainData)");
	_il2cpp_icall_func(___terrainData0);
}
// UnityEngine.Vector3 UnityEngine.TerrainData::get_size()
extern "C"  Vector3_t3722313464  TerrainData_get_size_m1871576403 (TerrainData_t657004131 * __this, const RuntimeMethod* method)
{
	Vector3_t3722313464  V_0;
	memset(&V_0, 0, sizeof(V_0));
	{
		TerrainData_get_size_Injected_m1617926404(__this, (&V_0), /*hidden argument*/NULL);
		Vector3_t3722313464  L_0 = V_0;
		return L_0;
	}
}
// System.Single[0...,0...,0...] UnityEngine.TerrainData::GetAlphamaps(System.Int32,System.Int32,System.Int32,System.Int32)
extern "C"  SingleU5B0___U2C0___U2C0___U5D_t1444911253* TerrainData_GetAlphamaps_m3939888263 (TerrainData_t657004131 * __this, int32_t ___x0, int32_t ___y1, int32_t ___width2, int32_t ___height3, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (TerrainData_GetAlphamaps_m3939888263_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	SingleU5B0___U2C0___U2C0___U5D_t1444911253* V_0 = NULL;
	{
		int32_t L_0 = ___x0;
		if ((((int32_t)L_0) < ((int32_t)0)))
		{
			goto IL_001e;
		}
	}
	{
		int32_t L_1 = ___y1;
		if ((((int32_t)L_1) < ((int32_t)0)))
		{
			goto IL_001e;
		}
	}
	{
		int32_t L_2 = ___width2;
		if ((((int32_t)L_2) < ((int32_t)0)))
		{
			goto IL_001e;
		}
	}
	{
		int32_t L_3 = ___height3;
		if ((((int32_t)L_3) >= ((int32_t)0)))
		{
			goto IL_0029;
		}
	}

IL_001e:
	{
		ArgumentException_t132251570 * L_4 = (ArgumentException_t132251570 *)il2cpp_codegen_object_new(ArgumentException_t132251570_il2cpp_TypeInfo_var);
		ArgumentException__ctor_m1312628991(L_4, _stringLiteral3361472150, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_4);
	}

IL_0029:
	{
		int32_t L_5 = ___x0;
		int32_t L_6 = ___y1;
		int32_t L_7 = ___width2;
		int32_t L_8 = ___height3;
		SingleU5B0___U2C0___U2C0___U5D_t1444911253* L_9 = TerrainData_Internal_GetAlphamaps_m346749885(__this, L_5, L_6, L_7, L_8, /*hidden argument*/NULL);
		V_0 = L_9;
		goto IL_003a;
	}

IL_003a:
	{
		SingleU5B0___U2C0___U2C0___U5D_t1444911253* L_10 = V_0;
		return L_10;
	}
}
// System.Single[0...,0...,0...] UnityEngine.TerrainData::Internal_GetAlphamaps(System.Int32,System.Int32,System.Int32,System.Int32)
extern "C"  SingleU5B0___U2C0___U2C0___U5D_t1444911253* TerrainData_Internal_GetAlphamaps_m346749885 (TerrainData_t657004131 * __this, int32_t ___x0, int32_t ___y1, int32_t ___width2, int32_t ___height3, const RuntimeMethod* method)
{
	typedef SingleU5B0___U2C0___U2C0___U5D_t1444911253* (*TerrainData_Internal_GetAlphamaps_m346749885_ftn) (TerrainData_t657004131 *, int32_t, int32_t, int32_t, int32_t);
	static TerrainData_Internal_GetAlphamaps_m346749885_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_Internal_GetAlphamaps_m346749885_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::Internal_GetAlphamaps(System.Int32,System.Int32,System.Int32,System.Int32)");
	SingleU5B0___U2C0___U2C0___U5D_t1444911253* retVal = _il2cpp_icall_func(__this, ___x0, ___y1, ___width2, ___height3);
	return retVal;
}
// System.Int32 UnityEngine.TerrainData::get_alphamapResolution()
extern "C"  int32_t TerrainData_get_alphamapResolution_m1154394489 (TerrainData_t657004131 * __this, const RuntimeMethod* method)
{
	int32_t V_0 = 0;
	{
		int32_t L_0 = TerrainData_get_Internal_alphamapResolution_m3110480181(__this, /*hidden argument*/NULL);
		V_0 = L_0;
		goto IL_000d;
	}

IL_000d:
	{
		int32_t L_1 = V_0;
		return L_1;
	}
}
// System.Single UnityEngine.TerrainData::GetAlphamapResolutionInternal()
extern "C"  float TerrainData_GetAlphamapResolutionInternal_m1173327220 (TerrainData_t657004131 * __this, const RuntimeMethod* method)
{
	typedef float (*TerrainData_GetAlphamapResolutionInternal_m1173327220_ftn) (TerrainData_t657004131 *);
	static TerrainData_GetAlphamapResolutionInternal_m1173327220_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_GetAlphamapResolutionInternal_m1173327220_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::GetAlphamapResolutionInternal()");
	float retVal = _il2cpp_icall_func(__this);
	return retVal;
}
// System.Int32 UnityEngine.TerrainData::get_Internal_alphamapResolution()
extern "C"  int32_t TerrainData_get_Internal_alphamapResolution_m3110480181 (TerrainData_t657004131 * __this, const RuntimeMethod* method)
{
	typedef int32_t (*TerrainData_get_Internal_alphamapResolution_m3110480181_ftn) (TerrainData_t657004131 *);
	static TerrainData_get_Internal_alphamapResolution_m3110480181_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_get_Internal_alphamapResolution_m3110480181_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::get_Internal_alphamapResolution()");
	int32_t retVal = _il2cpp_icall_func(__this);
	return retVal;
}
// System.Int32 UnityEngine.TerrainData::get_alphamapWidth()
extern "C"  int32_t TerrainData_get_alphamapWidth_m315223358 (TerrainData_t657004131 * __this, const RuntimeMethod* method)
{
	int32_t V_0 = 0;
	{
		int32_t L_0 = TerrainData_get_alphamapResolution_m1154394489(__this, /*hidden argument*/NULL);
		V_0 = L_0;
		goto IL_000d;
	}

IL_000d:
	{
		int32_t L_1 = V_0;
		return L_1;
	}
}
// System.Int32 UnityEngine.TerrainData::get_alphamapHeight()
extern "C"  int32_t TerrainData_get_alphamapHeight_m595805513 (TerrainData_t657004131 * __this, const RuntimeMethod* method)
{
	int32_t V_0 = 0;
	{
		int32_t L_0 = TerrainData_get_alphamapResolution_m1154394489(__this, /*hidden argument*/NULL);
		V_0 = L_0;
		goto IL_000d;
	}

IL_000d:
	{
		int32_t L_1 = V_0;
		return L_1;
	}
}
// System.Void UnityEngine.TerrainData::.cctor()
extern "C"  void TerrainData__cctor_m2936165929 (RuntimeObject * __this /* static, unused */, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (TerrainData__cctor_m2936165929_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		int32_t L_0 = TerrainData_GetBoundaryValue_m1103633233(NULL /*static, unused*/, 0, /*hidden argument*/NULL);
		((TerrainData_t657004131_StaticFields*)il2cpp_codegen_static_fields_for(TerrainData_t657004131_il2cpp_TypeInfo_var))->set_k_MaximumResolution_2(L_0);
		int32_t L_1 = TerrainData_GetBoundaryValue_m1103633233(NULL /*static, unused*/, 1, /*hidden argument*/NULL);
		((TerrainData_t657004131_StaticFields*)il2cpp_codegen_static_fields_for(TerrainData_t657004131_il2cpp_TypeInfo_var))->set_k_MinimumDetailResolutionPerPatch_3(L_1);
		int32_t L_2 = TerrainData_GetBoundaryValue_m1103633233(NULL /*static, unused*/, 2, /*hidden argument*/NULL);
		((TerrainData_t657004131_StaticFields*)il2cpp_codegen_static_fields_for(TerrainData_t657004131_il2cpp_TypeInfo_var))->set_k_MaximumDetailResolutionPerPatch_4(L_2);
		int32_t L_3 = TerrainData_GetBoundaryValue_m1103633233(NULL /*static, unused*/, 3, /*hidden argument*/NULL);
		((TerrainData_t657004131_StaticFields*)il2cpp_codegen_static_fields_for(TerrainData_t657004131_il2cpp_TypeInfo_var))->set_k_MaximumDetailPatchCount_5(L_3);
		int32_t L_4 = TerrainData_GetBoundaryValue_m1103633233(NULL /*static, unused*/, 4, /*hidden argument*/NULL);
		((TerrainData_t657004131_StaticFields*)il2cpp_codegen_static_fields_for(TerrainData_t657004131_il2cpp_TypeInfo_var))->set_k_MinimumAlphamapResolution_6(L_4);
		int32_t L_5 = TerrainData_GetBoundaryValue_m1103633233(NULL /*static, unused*/, 5, /*hidden argument*/NULL);
		((TerrainData_t657004131_StaticFields*)il2cpp_codegen_static_fields_for(TerrainData_t657004131_il2cpp_TypeInfo_var))->set_k_MaximumAlphamapResolution_7(L_5);
		int32_t L_6 = TerrainData_GetBoundaryValue_m1103633233(NULL /*static, unused*/, 6, /*hidden argument*/NULL);
		((TerrainData_t657004131_StaticFields*)il2cpp_codegen_static_fields_for(TerrainData_t657004131_il2cpp_TypeInfo_var))->set_k_MinimumBaseMapResolution_8(L_6);
		int32_t L_7 = TerrainData_GetBoundaryValue_m1103633233(NULL /*static, unused*/, 7, /*hidden argument*/NULL);
		((TerrainData_t657004131_StaticFields*)il2cpp_codegen_static_fields_for(TerrainData_t657004131_il2cpp_TypeInfo_var))->set_k_MaximumBaseMapResolution_9(L_7);
		return;
	}
}
// System.Void UnityEngine.TerrainData::get_size_Injected(UnityEngine.Vector3&)
extern "C"  void TerrainData_get_size_Injected_m1617926404 (TerrainData_t657004131 * __this, Vector3_t3722313464 * ___ret0, const RuntimeMethod* method)
{
	typedef void (*TerrainData_get_size_Injected_m1617926404_ftn) (TerrainData_t657004131 *, Vector3_t3722313464 *);
	static TerrainData_get_size_Injected_m1617926404_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainData_get_size_Injected_m1617926404_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainData::get_size_Injected(UnityEngine.Vector3&)");
	_il2cpp_icall_func(__this, ___ret0);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
