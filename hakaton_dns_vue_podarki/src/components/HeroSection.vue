<template>
  <section class="bg-gradient-to-r rounded-xl from-orange-500 to-orange-600 py-20 text-white text-center">
    <div class="container mx-auto px-4">
      <!-- Заголовок -->
      <h1 class="text-4xl font-extrabold mb-4 text-transparent bg-clip-text bg-gradient-to-r from-yellow-200 to-orange-300">
        Подберите идеальный подарок за несколько секунд!
      </h1>
      <p class="text-lg mb-8 max-w-2xl mx-auto">
        Не знаете, что подарить? Наш сервис поможет найти лучший подарок, идеально подходящий под ваш бюджет и предпочтения.
      </p>

      <!-- Поле ввода и кнопки -->
      <div class="mb-12 flex justify-center items-center gap-4">
        <input
          type="text"
          v-model="query"
          placeholder="Опишите, что вам нужно..."
          class="p-4 w-full sm:w-96 rounded-md text-gray-800 focus:ring-4 focus:ring-orange-600 transition duration-300 ease-in-out transform hover:scale-105"
        />
        <button
          @click="startSearch"
          class="p-4 bg-orange-700 text-white rounded-md hover:bg-orange-800 focus:ring-4 focus:ring-orange-600 transition duration-300 ease-in-out transform hover:scale-105"
        >
          Найти подарок
        </button>
      </div>

      <!-- Кнопки выбора категорий -->
      <div class="flex justify-center gap-2  flex-wrap">
        <button
          v-for="category in categories"
          :key="category"
          @click="setCategory(category)"
          :class="category === selectedCategory ? 'bg-orange-700 text-white' : 'bg-white text-gray-800'"
          class="p-2 rounded-full shadow-lg hover:bg-orange-600 hover:text-white transition duration-300 ease-in-out"
        >
          {{ category }}
        </button>
      </div>

      <!-- Результаты поиска -->
      <div v-if="results.length > 0" class="mt-8">
        <h2 class="text-xl font-semibold mb-4">Результаты подбора:</h2>
        <div class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-8">
          <div
            v-for="(item, index) in results.slice(0, 3)"
            :key="index"
            class="bg-white p-6 rounded-lg shadow-lg text-gray-800 transform transition duration-300 ease-in-out hover:scale-105"
          >
            <img :src="item.img" alt="product" class="w-full h-48 object-cover rounded-md mb-6 shadow-md" />
            <h3 class="font-semibold text-lg mb-2">{{ item.name }}</h3>
            <p class="text-sm text-gray-600 mb-4">{{ item.description }}</p>
            <div class="flex justify-between items-center">
              <p class="font-semibold text-orange-600">{{ item.price }} ₽</p>
              <p v-if="item.oldPrice" class="text-gray-500 line-through">{{ item.oldPrice }} ₽</p>
              <p v-if="item.discount" class="text-green-600">{{ item.discount }}% скидка</p>
            </div>
          </div>
        </div>
      </div>
      <div v-else class="mt-8 text-lg text-gray-600">
        <p>Нет результатов для вашего запроса.</p>
      </div>
    </div>
  </section>
</template>

<script lang="ts">
import { products } from '../../data/Products';

export default {
  data: function () {
    return {
      query: '',
      selectedCategory: 'Все товары',
      results: products, // Изначально показываем все товары
      categories: [] as string[], // Массив для динамических категорий
    };
  },
  created() {
    // Извлекаем уникальные категории из списка товаров
    this.categories = ['Все товары', ...new Set(products.map(product => product.category))];
  },
  methods: {
    startSearch() {
      if (this.query || this.selectedCategory !== 'Все товары') {
        this.results = products.filter((product) => {
          const matchesQuery =
            this.query === '' ||
            product.name.toLowerCase().includes(this.query.toLowerCase()) ||
            product.description.toLowerCase().includes(this.query.toLowerCase());
          const matchesCategory = this.selectedCategory === 'Все товары' || product.category === this.selectedCategory;

          return matchesQuery && matchesCategory;
        });
      } else {
        this.results = products; // Если нет фильтров, показываем все товары
      }
    },
    setCategory(category: string) {
      this.selectedCategory = category;
      this.startSearch(); // Автоматический поиск при изменении категории
    },
  },
};
</script>
