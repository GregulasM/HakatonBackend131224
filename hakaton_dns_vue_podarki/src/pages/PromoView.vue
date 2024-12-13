<template>
  <div class="bg-gradient-to-br from-orange-50 to-orange-100 text-gray-800 p-6 sm:p-8 rounded-2xl shadow-2xl max-w-2xl mx-auto flex flex-col gap-8">
    <!-- Ссылка назад -->
    <router-link
      to="/"
      class="text-orange-600 font-medium hover:underline hover:text-orange-800 transition-colors self-start"
    >
      ← Назад
    </router-link>

    <!-- Заголовок -->
    <h1 class="text-4xl sm:text-5xl font-extrabold text-center leading-snug">
      Выберите получателя подарка
    </h1>
    <p class="text-center text-lg text-gray-600">
      Поможем подобрать идеальный подарок для каждого!
    </p>

    <!-- Форма -->
    <form class="flex flex-col gap-6 text-lg" @submit.prevent="handleSubmit">
      <!-- Варианты выбора -->
      <div class="space-y-5">
        <div class="flex items-center gap-4">
          <input
            type="radio"
            id="family"
            name="gift"
            value="family"
            class="h-6 w-6 text-orange-500 border-gray-300 focus:ring-orange-400 cursor-pointer"
            v-model="selectedOption"
          />
          <label
            for="family"
            class="font-medium cursor-pointer hover:text-orange-600"
          >
            🏠 Родным
          </label>
        </div>

        <div class="flex items-center gap-4">
          <input
            type="radio"
            id="colleagues"
            name="gift"
            value="colleagues"
            class="h-6 w-6 text-orange-500 border-gray-300 focus:ring-orange-400 cursor-pointer"
            v-model="selectedOption"
          />
          <label
            for="colleagues"
            class="font-medium cursor-pointer hover:text-orange-600"
          >
            💼 Коллегам
          </label>
        </div>

        <div class="flex items-center gap-4">
          <input
            type="radio"
            id="friends"
            name="gift"
            value="friends"
            class="h-6 w-6 text-orange-500 border-gray-300 focus:ring-orange-400 cursor-pointer"
            v-model="selectedOption"
          />
          <label
            for="friends"
            class="font-medium cursor-pointer hover:text-orange-600"
          >
            👫 Друзьям
          </label>
        </div>
      </div>

      <!-- Кнопка отправки -->
      <!-- Кнопка отправки -->
      <button
        type="submit"
        class="w-full py-3 bg-orange-500 text-white font-bold rounded-xl shadow-lg hover:bg-orange-600 transition-all duration-200"
      >
        Найти подарок
      </button>
    </form>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import { useRouter } from 'vue-router';

const selectedOption = ref('family');
const router = useRouter();

const handleSubmit = () => {
  router.push({
    name: 'list', // Переход на ListView
    query: { category: selectedOption.value },
  });
};

const getOptionName = (option: string) => {
  const options: Record<string, string> = {
    family: 'Родным',
    colleagues: 'Коллегам',
    friends: 'Друзьям',
  };
  return options[option] || 'Кому-то';
};
</script>

<style scoped>
/* Адаптивная отступка для больших экранов */
@media (min-width: 640px) {
  form {
    padding: 0 2rem;
  }
}
</style>
