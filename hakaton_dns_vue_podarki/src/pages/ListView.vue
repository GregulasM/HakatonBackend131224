<template>
  <div class="bg-gradient-to-br from-orange-50 to-orange-100 text-gray-800 p-6 sm:p-8 rounded-2xl shadow-2xl max-w-4xl mx-auto flex flex-col gap-8">
    <!-- Заголовок -->
    <router-link
      to="/promo"
      class="text-orange-600 font-medium hover:underline hover:text-orange-800 transition-colors self-start"
    >
      ← Назад
    </router-link>
    <h1 class="text-4xl sm:text-5xl font-extrabold text-center leading-snug">
      Ответьте на вопросы
    </h1>

    <!-- Опросники -->
    <div class="space-y-8">
      <div>
        <h2 class="text-2xl font-semibold">Какой тип подарка вы ищете?</h2>
        <div class="flex flex-wrap gap-4">
          <label v-for="option in question1Options" :key="option" class="flex items-center gap-2">
            <input
              type="radio"
              :value="option"
              v-model="answers.question1"
              class="h-6 w-6 text-orange-500 border-gray-300 focus:ring-orange-400 cursor-pointer"
            />
            {{ option }}
          </label>
        </div>
      </div>

      <div>
        <h2 class="text-2xl font-semibold">Каков ваш бюджет?</h2>
        <div class="flex flex-wrap gap-4">
          <label v-for="option in question2Options" :key="option" class="flex items-center gap-2">
            <input
              type="radio"
              :value="option"
              v-model="answers.question2"
              class="h-6 w-6 text-orange-500 border-gray-300 focus:ring-orange-400 cursor-pointer"
            />
            {{ option }}
          </label>
        </div>
      </div>

      <div>
        <h2 class="text-2xl font-semibold">Для кого предназначен подарок?</h2>
        <div class="flex flex-wrap gap-4">
          <label v-for="option in question3Options" :key="option" class="flex items-center gap-2">
            <input
              type="radio"
              :value="option"
              v-model="answers.question3"
              class="h-6 w-6 text-orange-500 border-gray-300 focus:ring-orange-400 cursor-pointer"
            />
            {{ option }}
          </label>
        </div>
      </div>
    </div>

    <!-- Кнопка завершения -->
    <button
      class="w-full py-3 bg-orange-500 text-white font-bold rounded-xl shadow-lg hover:bg-orange-600 transition-all duration-200"
      @click="submitAnswers"
    >
      Завершить опрос
    </button>

    <!-- Панель результатов -->
    <div v-if="showResults" class="mt-8">
      <h2 class="text-xl font-semibold mb-4">Результаты:</h2>
      <div class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-8">
        <div
          v-for="item in results"
          :key="item.id"
          class="bg-white p-6 rounded-lg shadow-lg text-gray-800 transform transition duration-300 ease-in-out hover:scale-105"
        >
          <h3 class="font-semibold text-lg mb-2">{{ item.name }}</h3>
          <p class="text-sm text-gray-600 mb-4">{{ item.description }}</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import axios from 'axios';

const question1Options = ['Гаджеты', 'Электроника', 'Комплектующие', 'Для дома'];
const question2Options = ['До 1000 ₽', '1000-5000 ₽', '5000-10000 ₽', 'Более 10000 ₽'];
const question3Options = ['Родителям', 'Друзьям', 'Коллегам', 'Детям'];

const answers = ref({
  question1: '',
  question2: '',
  question3: '',
});

const showResults = ref(false);
const results = ref([]);

const apiRoutes = [
  'laptops-selection',
  'mousepads-selection',
  'mice-selection',
  'soft-toys-selection',
  'speakers-selection',
];

const submitAnswers = async () => {
  try {
    let selectedRoute;
    if (answers.value.question2 === 'До 1000 ₽') {
      selectedRoute = 'mousepads-selection';
    } else {
      selectedRoute = apiRoutes[Math.floor(Math.random() * apiRoutes.length)];
    }

    // API
    const response = await axios.get(`https://localhost:7020/api/products/${selectedRoute}`);

    // Объединение в массив, йоу
    results.value = [];
    for (const key in response.data) {
      if (Array.isArray(response.data[key])) {
        results.value.push(...response.data[key]);
      } else if (response.data[key]) {
        results.value.push(response.data[key]);
      }
    }

    showResults.value = true;
  } catch (error) {
    console.error('Ошибка при получении данных:', error);
  }
};
</script>
