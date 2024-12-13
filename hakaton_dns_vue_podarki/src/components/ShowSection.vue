<template>
  <div class="fixed snow -z-20 animate-snow"></div>
  <div class="fixed stars -z-20 w-full top-0 left-0 p-4">
    <div class="flex flex-nowrap space-x-6 overflow-x-auto whitespace-nowrap text-lg font-semibold text-white animate-slide">
      <div class="star">ТЕХНИКА</div>
      <div class="star">ПОДАРКИ</div>
      <div class="star">ЭТО ВОЛШЕБСТВО</div>
      <div class="star">ПРАЗДНИК К НАМ ПРИХОДИТ</div>
      <div class="star">ЧУДО</div>
      <div class="star">ВОТ ЭТО ПОВОРОТ</div>
      <div class="star">СТАРТУЕМ</div>
      <div class="star">МЫ ВПЕРЕДИ</div>
      <div class="star">ТУТ МОГЛА БЫТЬ ВАША РЕКЛАМА</div>
      <div class="star">ЗВЕЗДЫ ЗОВУТ</div>
    </div>
  </div>
</template>
<script>
export default {
  name: 'ShowSection'
}
</script>
<style lang="scss">
@mixin sp-layout {
  @media screen and (max-width: 800px) {
    @content;
  }
}

body {
  display: flex;
  justify-content: center;
  align-items: center;
  min-height: 100vh;
  background: linear-gradient(
      213.92deg,
      #812a00 0%,
      #ff5900 100%
  );
}

@function random_range($min, $max) {
  $rand: random();
  $random_range: $min + floor($rand * (($max - $min) + 1));
  @return $random_range;
}

.stars {
  background-repeat: no-repeat;
  position: fixed;
  top: 0;
  left: 0;
  width: 60%;
  height: 60%;
  transform: rotate(-45deg);
}

.star {
  $star-count: 15;
  --star-tail-length: 6em;
  --star-tail-height: 2px;
  --star-width: calc(var(--star-tail-length) / 6);
  --fall-duration: 11s;
  --tail-fade-duration: var(--fall-duration);
  z-index: 10;


  position: absolute;
  top: var(--top-offset);
  left: 0;
  width: var(--star-tail-length);
  height: var(--star-tail-height);
  color: #ff7c35;
  background: linear-gradient(45deg, currentColor, transparent);
  border-radius: 50%;
  filter: drop-shadow(0 0 6px currentColor);
  transform: translate3d(104em, 0, 0);
  animation: fall var(--fall-duration) var(--fall-delay) linear infinite,
  tail-fade var(--tail-fade-duration) var(--fall-delay) ease-out infinite;

  @include sp-layout {
    // For mobile performance, tail-fade animation will be removed QAQ
    animation: fall var(--fall-duration) var(--fall-delay) linear infinite;
  }

  @for $i from 1 through $star-count {
    &:nth-child(#{$i}) {
      --star-tail-length: #{random_range(500em, 750em) / 100};
      --top-offset: #{random_range(0vh, 10000vh) / 100};
      --fall-duration: #{random_range(6000, 12000s) / 1000};
      --fall-delay: #{random_range(0, 1s) / 1000};
    }
  }

  &::before,
  &::after {
    position: absolute;
    content: '';
    top: 0;
    left: calc(var(--star-width) / -2);
    width: var(--star-width);
    height: 100%;
    background: linear-gradient(45deg, transparent, currentColor, transparent);
    border-radius: inherit;
    animation: blink 2s linear infinite;
  }

  &::before {
    transform: rotate(45deg);
  }

  &::after {
    transform: rotate(-45deg);
  }
}

@keyframes fall {
  to {
    transform: translate3d(-30em, 0, 0);
  }
}

@keyframes tail-fade {
  0%,
  50% {
    width: var(--star-tail-length);
    opacity: 1;
  }

  70%,
  80% {
    width: 0;
    opacity: 0.4;
  }

  100% {
    width: 0;
    opacity: 0;
  }
}

@keyframes blink {
  50% {
    opacity: 0.6;
  }
}
</style>
<style lang="scss">
$d: 60; // density
$w: 900; // grid size
$s: 6s; // speed

// Generate the snow image using radial gradients
$grad: ();
@for $i from 0 to $d {
  $v: random(4) + 2;
  $a: random(5) * 0.1 + 0.5;
  $grad: $grad,
  radial-gradient(
      $v + px $v + px at (random($w - $v * 2) + $v) + px (random($w - $v * 2) + $v) + px,
      rgba(255, 255, 255, $a) 50%,
      rgba(0, 0, 0, 0)
  ) !global;
}

// The CSS

.snow,
.snow:before,
.snow:after {
  position: absolute;
  top: -$w + px;
  left: 0;
  bottom: 0;
  right: 0;
  background-image: $grad;
  background-size: $w + px $w + px;
  animation: snow $s linear infinite;
  content: '';
}

.snow:after {
  margin-left:  math(-$w, 2) or calc(-1 * $w / 2);
  opacity: 0.4;
  animation-duration: $s * 2;
  animation-direction: reverse;
  filter: blur(3px);
}

.snow:before {
  animation-duration: $s * 3;
  animation-direction: reverse;
  margin-left: -$w/2 + px;
  opacity: 0.65;
  filter: blur(1.5px);
}

@keyframes snow {
  to {
    transform: translateY($w + px) ;
  }
}
</style>
