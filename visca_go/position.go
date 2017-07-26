package visca

import "time"
import "math"

type AngularPosition struct {
	DegreesPerEncoderCount float64
	encoderCount int16
	positionChanged []chan time.Time
}

func NewAngularPosition(degreesPerEncoderCount float64) *AngularPosition {
	result := new(AngularPosition)
	result.DegreesPerEncoderCount = degreesPerEncoderCount
	return result
}

func (a *AngularPosition) AddPositionChangedEventHandler(c chan time.Time) {
	a.positionChanged = append(a.positionChanged, c)
}

func (a *AngularPosition) EncoderCount() int16 {
	return a.encoderCount
}

func (a *AngularPosition) SetEncoderCount(value int16) {
	a.encoderCount = value
	for _, c := range a.positionChanged {
		c <- time.Now()
	}
}

func (a *AngularPosition) Radians() float64 {
	return float64(a.encoderCount) * a.DegreesPerEncoderCount * (math.Pi / 180.0)
}

func (a *AngularPosition) SetRadians(value float64) {
	a.SetEncoderCount(int16(value * (180.0 / math.Pi) / a.DegreesPerEncoderCount))
}

func (a *AngularPosition) Degrees() float64 {
	return a.Radians() * (180.0 / math.Pi)
}

func (a *AngularPosition) SetDegrees(value float64) {
	a.SetEncoderCount(int16(value / a.DegreesPerEncoderCount))
}