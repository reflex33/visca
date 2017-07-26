package visca

type visca_code byte
const (
	HEADER visca_code = 0x80
	COMMAND visca_code = 0x01
	INQUIRY visca_code = 0x09
	TERMINATOR visca_code = 0xFF

	CATEGORY_CAMERA1 visca_code = 0x04
	CATEGORY_PAN_TILTER visca_code = 0x06
	CATEGORY_CAMERA2 visca_code = 0x07

	SUCCESS visca_code = 0x00
	FAILURE visca_code = 0xFF

	// Response types 
	RESPONSE_CLEAR visca_code = 0x40
	RESPONSE_ADDRESS visca_code = 0x30
	RESPONSE_ACK visca_code = 0x40
	RESPONSE_COMPLETED visca_code = 0x50
	RESPONSE_ERROR visca_code = 0x60
	RESPONSE_TIMEOUT visca_code = 0x70  // Not offical I created this to handle serial port timeouts

	// Commands/inquiries codes
	POWER visca_code = 0x00
	DEVICE_INFO visca_code = 0x02
	KEYLOCK visca_code = 0x17
	ID visca_code = 0x22
	ZOOM visca_code = 0x07
	ZOOM_STOP visca_code = 0x00
	ZOOM_TELE visca_code = 0x02
	ZOOM_WIDE visca_code = 0x03
	ZOOM_TELE_SPEED visca_code = 0x20
	ZOOM_WIDE_SPEED visca_code = 0x30
	ZOOM_VALUE visca_code = 0x47
	ZOOM_FOCUS_VALUE visca_code = 0x47
	DZOOM visca_code = 0x06
	FOCUS visca_code = 0x08
	FOCUS_STOP visca_code = 0x00
	FOCUS_FAR visca_code = 0x02
	FOCUS_NEAR visca_code = 0x03
	FOCUS_FAR_SPEED visca_code = 0x20
	FOCUS_NEAR_SPEED visca_code = 0x30
	FOCUS_VALUE visca_code = 0x48
	FOCUS_AUTO visca_code = 0x38
	FOCUS_AUTO_MAN visca_code = 0x10
	FOCUS_ONE_PUSH visca_code = 0x18
	FOCUS_ONE_PUSH_TRIG visca_code = 0x01
	FOCUS_ONE_PUSH_INF visca_code = 0x02
	FOCUS_AUTO_SENSE visca_code = 0x58
	FOCUS_AUTO_SENSE_HIGH visca_code = 0x02
	FOCUS_AUTO_SENSE_LOW visca_code = 0x03
	FOCUS_NEAR_LIMIT visca_code = 0x28
	WB visca_code = 0x35
	WB_AUTO visca_code = 0x00
	WB_INDOOR visca_code = 0x01
	WB_OUTDOOR visca_code = 0x02
	WB_ONE_PUSH visca_code = 0x03
	WB_ATW visca_code = 0x04
	WB_MANUAL visca_code = 0x05
	WB_ONE_PUSH_TRIG visca_code = 0x05
	RGAIN visca_code = 0x03
	RGAIN_VALUE visca_code = 0x43
	BGAIN visca_code = 0x04
	BGAIN_VALUE visca_code = 0x44
	AUTO_EXP visca_code = 0x39
	AUTO_EXP_FULL_AUTO visca_code = 0x00
	AUTO_EXP_MANUAL visca_code = 0x03
	AUTO_EXP_SHUTTER_PRIORITY visca_code = 0x0A
	AUTO_EXP_IRIS_PRIORITY visca_code = 0x0B
	AUTO_EXP_GAIN_PRIORITY visca_code = 0x0C
	AUTO_EXP_BRIGHT visca_code = 0x0D
	AUTO_EXP_SHUTTER_AUTO visca_code = 0x1A
	AUTO_EXP_IRIS_AUTO visca_code = 0x1B
	AUTO_EXP_GAIN_AUTO visca_code = 0x1C
	SLOW_SHUTTER visca_code = 0x5A
	SLOW_SHUTTER_AUTO visca_code = 0x02
	SLOW_SHUTTER_MANUAL visca_code = 0x03
	SHUTTER visca_code = 0x0A
	SHUTTER_VALUE visca_code = 0x4A
	IRIS visca_code = 0x0B
	IRIS_VALUE visca_code = 0x4B
	GAIN visca_code = 0x0C
	GAIN_VALUE visca_code = 0x4C
	BRIGHT visca_code = 0x0D
	BRIGHT_VALUE visca_code = 0x4D
	EXP_COMP visca_code = 0x0E
	EXP_COMP_POWER visca_code = 0x3E
	EXP_COMP_VALUE visca_code = 0x4E
	BACKLIGHT_COMP visca_code = 0x33
	APERTURE visca_code = 0x02
	APERTURE_VALUE visca_code = 0x42
	ZERO_LUX visca_code = 0x01
	IR_LED visca_code = 0x31
	WIDE_MODE visca_code = 0x60
	WIDE_MODE_OFF visca_code = 0x00
	WIDE_MODE_CINEMA visca_code = 0x01
	WIDE_MODE_16_9 visca_code = 0x02
	MIRROR visca_code = 0x61
	FREEZE visca_code = 0x62
	PICTURE_EFFECT visca_code = 0x63
	PICTURE_EFFECT_OFF visca_code = 0x00
	PICTURE_EFFECT_PASTEL visca_code = 0x01
	PICTURE_EFFECT_NEGATIVE visca_code = 0x02
	PICTURE_EFFECT_SEPIA visca_code = 0x03
	PICTURE_EFFECT_BW visca_code = 0x04
	PICTURE_EFFECT_SOLARIZE visca_code = 0x05
	PICTURE_EFFECT_MOSAIC visca_code = 0x06
	PICTURE_EFFECT_SLIM visca_code = 0x07
	PICTURE_EFFECT_STRETCH visca_code = 0x08
	DIGITAL_EFFECT visca_code = 0x64
	DIGITAL_EFFECT_OFF visca_code = 0x00
	DIGITAL_EFFECT_STILL visca_code = 0x01
	DIGITAL_EFFECT_FLASH visca_code = 0x02
	DIGITAL_EFFECT_LUMI visca_code = 0x03
	DIGITAL_EFFECT_TRAIL visca_code = 0x04
	DIGITAL_EFFECT_LEVEL visca_code = 0x65
	MEMORY visca_code = 0x3F
	MEMORY_RESET visca_code = 0x00
	MEMORY_SET visca_code = 0x01
	MEMORY_RECALL visca_code = 0x02
	DISPLAY visca_code = 0x15
	DISPLAY_TOGGLE visca_code = 0x10
	DATE_TIME_SET visca_code = 0x70
	DATE_DISPLAY visca_code = 0x71
	TIME_DISPLAY visca_code = 0x72
	TITLE_DISPLAY visca_code = 0x74
	TITLE_DISPLAY_CLEAR visca_code = 0x00
	TITLE_SET visca_code = 0x73
	TITLE_SET_PARAMS visca_code = 0x00
	TITLE_SET_PART1 visca_code = 0x01
	TITLE_SET_PART2 visca_code = 0x02
	IRRECEIVE visca_code = 0x08
	IRRECEIVE_ON visca_code = 0x02
	IRRECEIVE_OFF visca_code = 0x03
	IRRECEIVE_ONOFF visca_code = 0x10
	PT_DRIVE visca_code = 0x01
	PT_DRIVE_HORIZ_LEFT visca_code = 0x01
	PT_DRIVE_HORIZ_RIGHT visca_code = 0x02
	PT_DRIVE_HORIZ_STOP visca_code = 0x03
	PT_DRIVE_VERT_UP visca_code = 0x01
	PT_DRIVE_VERT_DOWN visca_code = 0x02
	PT_DRIVE_VERT_STOP visca_code = 0x03
	PT_ABSOLUTE_POSITION visca_code = 0x02
	PT_RELATIVE_POSITION visca_code = 0x03
	PT_HOME visca_code = 0x04
	PT_RESET visca_code = 0x05
	PT_LIMITSET visca_code = 0x07
	PT_LIMITSET_SET visca_code = 0x00
	PT_LIMITSET_CLEAR visca_code = 0x01
	PT_LIMITSET_SET_UR visca_code = 0x01
	PT_LIMITSET_SET_DL visca_code = 0x00
	PT_DATASCREEN visca_code = 0x06
	PT_DATASCREEN_ON visca_code = 0x02
	PT_DATASCREEN_OFF visca_code = 0x03
	PT_DATASCREEN_ONOFF visca_code = 0x10

	PT_VIDEOSYSTEM_INQ visca_code = 0x23
	PT_MODE_INQ visca_code = 0x10
	PT_MAXSPEED_INQ visca_code = 0x11
	PT_POSITION_INQ visca_code = 0x12
	PT_DATASCREEN_INQ visca_code = 0x06
)

type ZOOM_DIRECTION int
const (
	IN ZOOM_DIRECTION = iota
	OUT
	NONE
)

type drive_status int
const (
	FULL_STOP drive_status = iota
	JOG
	STOP_JOG
	ABSOLUTE
	STOP_ABSOLUTE
)
