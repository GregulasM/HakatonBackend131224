<script setup lang="ts">
import { ref } from 'vue';
import { products } from '../../data/Products';

// Функция для выбора случайных товаров
const getRandomProducts = (count: number) => {
  const shuffled = [...products].sort(() => 0.5 - Math.random()); // Перемешиваем товары
  return shuffled.slice(0, count); // Возвращаем первые 5 товаров
}

// Выбираем 5 случайных товаров
const randomProducts = ref(getRandomProducts(5));
</script>

<template>
  <div class="space-y-6 lg:space-y-8">
    <div
      v-for="(product, index) in randomProducts"
      :key="index"
      class="flex flex-col bg-white/60 md:flex-row items-center gap-6 p-6 border border-gray-200 rounded-xl shadow-sm "
    >
      <!-- Изображение продукта -->
      <img
        class="w-48 h-48 bg-white p-2 rounded-lg object-cover "
        :src="product.img"
        :alt="product.name"
      />

      <!-- Описание продукта -->
      <div class="flex flex-col gap-4 text-center md:text-left w-full">
        <!-- Название -->
        <h2 class="text-2xl font-semibold text-gray-800 hover:text-orange-500 transition-colors">
          {{ product.name }}
        </h2>

        <!-- Описание -->
        <p class="text-gray-700 text-base">
          {{ product.description }}
        </p>
        <p class="text-gray-700 bg-gray-100 w-fit p-2 rounded-full text-base">
          {{ product.category }}
        </p>
        <!-- Цены -->
        <div class="flex flex-col md:flex-row items-center gap-4 mt-2">
          <div class="text-xl font-bold text-orange-500">{{ product.price }} ₽</div>
          <div class="text-base text-gray-500 line-through">{{ product.oldPrice }} ₽</div>
          <div
            v-if="product.discount"
            class="px-3 py-1 text-sm font-semibold bg-orange-100 text-orange-600 rounded-lg"
          >
            -{{ product.discount }}%
          </div>
        </div>

        <!-- Кнопка -->
        <button
          class="w-fit px-6 py-2 mt-4 bg-orange-500 text-white font-semibold rounded-lg hover:bg-orange-600 transition"
        >
          Подробнее
        </button>
      </div>
    </div>
  </div>
</template>
