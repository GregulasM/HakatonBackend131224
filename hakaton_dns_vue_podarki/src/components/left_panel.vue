<template>
  <div class="bg-gradient-to-br from-orange-600 to-orange-400 text-white p-10 md:p-14 rounded-xl shadow-2xl text-center space-y-8">
    <h1 class="text-4xl md:text-5xl font-extrabold tracking-tight leading-snug">
      🎉 Новогодняя акция!
    </h1>

    <p class="text-lg md:text-xl font-medium max-w-3xl mx-auto leading-relaxed">
      Подарите радость себе и близким! Наслаждайтесь эксклюзивными скидками, праздничной атмосферой и специальными предложениями, доступными только сейчас.
    </p>

    <ul class="space-y-3 text-base md:text-lg font-medium leading-snug">
      <li>✔️ Скидки до <span class="font-bold text-yellow-200">50%</span> на популярные товары</li>
      <li>🎁 Подарочная упаковка совершенно бесплатно</li>
      <li>🚚 Бесплатная доставка при заказе от <span class="font-bold text-yellow-200">3000₽</span></li>
    </ul>

    <router-link
      to="/promo"
      class="inline-block px-10 py-4 bg-white text-orange-600 font-bold rounded-full shadow-lg hover:bg-orange-100 hover:scale-105 transition-all duration-300"
    >
      Узнать больше
    </router-link>
  </div>
</template>

<script setup lang="ts">
// Скрипт пустой, так как логика не требуется в данной секции
</script>

<style scoped>
/* Стили можно добавить, если требуется */
</style>
