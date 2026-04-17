shader_type canvas_item;

uniform sampler2D SCREEN_TEXTURE: hint_screen_texture, filter_linear_mipmap;

// Tamaño de la zona enfocada (0.0 - 1.0)
uniform float focus_radius : hint_range(0.0, 1.0) = 0.3;

// Suavidad de la transición entre foco y desenfoque
uniform float softness : hint_range(0.0, 1.0) = 0.2;

// Intensidad del desenfoque +blur_samples -rendimiento 
uniform int blur_samples : hint_range(1, 16) = 16; //manejar val*2
uniform float blur_strength : hint_range(0.0, 20.0) = 6.0;

// Posición del centro del foco en pantalla (0.0 - 1.0)
uniform vec2 focus_center = vec2(0.5, 0.5);

void fragment() {
    vec2 uv = SCREEN_UV;

    vec2 aspect_correction = vec2(1.0, SCREEN_PIXEL_SIZE.x / SCREEN_PIXEL_SIZE.y);
    float dist = length((uv - focus_center) * aspect_correction);

    float blur_amount = smoothstep(focus_radius, focus_radius + softness, dist);

    vec4 blurred = vec4(0.0);
    float total = 0.0;

    for (int i = 0; i < blur_samples; i++) {
        float t = float(i) / float(blur_samples);
        float angle = t * 6.28318;
        vec2 offset = vec2(cos(angle), sin(angle))
                      * blur_strength
                      * blur_amount
                      * SCREEN_PIXEL_SIZE;
        blurred += texture(SCREEN_TEXTURE, uv + offset);
        total += 1.0;
    }

    blurred /= total;

    vec4 original = texture(SCREEN_TEXTURE, uv);
    COLOR = mix(original, blurred, blur_amount);
}