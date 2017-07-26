package visca

import "testing"
import "time"

func TestAngularPositionEncoderCount(t *testing.T) {
	// Test for default position
	var a AngularPosition
	if a.EncoderCount() != 0 {
		t.Errorf("EncoderCount == %d, want %d", a.EncoderCount(), 0)
	}

	// Test for changed value and positionChanged event
	channel := make(chan time.Time)
	var resultTime time.Time
	a.AddPositionChangedEventHandler(channel)
	go func() {  // positionChanged event handler
		for {
			resultTime = <-channel
		}
	}()
	var wantEncoder int16 = 500
	a.SetEncoderCount(wantEncoder)
	var wantTime time.Time = time.Now().Round(time.Second)
	if a.EncoderCount() != wantEncoder {
		t.Errorf("EncoderCount == %d, want %d", a.EncoderCount(), wantEncoder)
	}
	if resultTime.Round(time.Second) != wantTime {
		t.Errorf("resultTime == %v, want %v", resultTime, wantTime)
	}
}

func TestAngularPositionRadians (t *testing.T) {
	// Test for default position
	a := NewAngularPosition(0.075)
	if a.Radians() != 0 {
		t.Errorf("Radians == %d, want %d", a.Radians(), 0)
	}

	// Test for changed value and positionChanged event
	channel := make(chan time.Time)
	var resultTime time.Time
	a.AddPositionChangedEventHandler(channel)
	go func() {  // positionChanged event handler
		for {
			resultTime = <-channel
		}
	}()
	cases := []float64{0.785398, -0.785398, 1.0}
	for _, c := range cases {
		a.SetRadians(c)
		var wantTime time.Time = time.Now().Round(time.Second)
		if a.Radians() != c {
			t.Errorf("Radians == %f, want %f", a.Radians(), c)
		}
		if resultTime.Round(time.Second) != wantTime {
		t.Errorf("resultTime == %v, want %v", resultTime, wantTime)
		}
	}
}

func TestAngularPositionDegrees (t *testing.T) {
	// Test for default position
	a := NewAngularPosition(0.075)
	if a.Degrees() != 0 {
		t.Errorf("Degrees == %d, want %d", a.Degrees(), 0)
	}

	// Test for changed value and positionChanged event
	channel := make(chan time.Time)
	var resultTime time.Time
	a.AddPositionChangedEventHandler(channel)
	go func() {  // positionChanged event handler
		for {
			resultTime = <-channel
		}
	}()
	cases := []float64{45.3, -19.8, 85.2}
	for _, c := range cases {
		a.SetDegrees(c)
		var wantTime time.Time = time.Now().Round(time.Second)
		if a.Degrees() != c {
			t.Errorf("Degrees == %f, want %f", a.Degrees(), c)
		}
		if resultTime.Round(time.Second) != wantTime {
		t.Errorf("resultTime == %v, want %v", resultTime, wantTime)
		}
	}
}