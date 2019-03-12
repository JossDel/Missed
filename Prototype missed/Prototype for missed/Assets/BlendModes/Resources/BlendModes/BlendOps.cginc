#ifndef BLEND_OPS
#define BLEND_OPS

fixed4 result;

#ifdef BMDarken
result = Darken(grabColor, color);
#endif
#ifdef BMMultiply
result = Multiply(grabColor, color);
#endif
#ifdef BMColorBurn
result = ColorBurn(grabColor, color);
#endif
#ifdef BMLinearBurn
result = LinearBurn(grabColor, color);
#endif
#ifdef BMDarkerColor
result = DarkerColor(grabColor, color);
#endif
#ifdef BMLighten
result = Lighten(grabColor, color);
#endif
#ifdef BMScreen
result = Screen(grabColor, color);
#endif
#ifdef BMColorDodge
result = ColorDodge(grabColor, color);
#endif
#ifdef BMLinearDodge
result = LinearDodge(grabColor, color);
#endif
#ifdef BMLighterColor
result = LighterColor(grabColor, color);
#endif
#ifdef BMOverlay
result = Overlay(grabColor, color);
#endif
#ifdef BMSoftLight
result = SoftLight(grabColor, color);
#endif
#ifdef BMHardLight
result = HardLight(grabColor, color);
#endif
#ifdef BMVividLight
result = VividLight(grabColor, color);
#endif
#ifdef BMLinearLight
result = LinearLight(grabColor, color);
#endif
#ifdef BMPinLight
result = PinLight(grabColor, color);
#endif
#ifdef BMHardMix
result = HardMix(grabColor, color);
#endif
#ifdef BMDifference
result = Difference(grabColor, color);
#endif
#ifdef BMExclusion
result = Exclusion(grabColor, color);
#endif
#ifdef BMSubtract
result = Subtract(grabColor, color);
#endif
#ifdef BMDivide
result = Divide(grabColor, color);
#endif
#ifdef BMHue
result = Hue(grabColor, color);
#endif
#ifdef BMSaturation
result = Saturation(grabColor, color);
#endif
#ifdef BMColor
result = Color(grabColor, color);
#endif
#ifdef BMLuminosity
result = Luminosity(grabColor, color);
#endif

// --------------- selective blending (experimental) ---------------
//float modifiedAlpha = round(color.a * 100) / 100; // free mask component position
//modifiedAlpha -= .002; // set shift
//color.a = result.a = lerp(color.a, modifiedAlpha, _IsSelectiveBlendingActive); // inject mask if selective blending is active
//	
//float isMaskDetected = ceil(frac(grabColor.a * 100)); // check if grabbed pixel has mask
//isMaskDetected = lerp(1, isMaskDetected, _IsSelectiveBlendingActive); // force true if selective blending is not active
//return lerp(color, result, isMaskDetected);
// --------------- selective blending (experimental) ---------------

return result;
 
#endif
