<script setup>
import SearchPanel from '@/components/search_panel.vue';
import LeftPanel from '@/components/left_panel.vue';
import HeroSection from '@/components/HeroSection.vue';
</script>

<template>
  <div class=" py-16 px-4">
    <div class="container mx-auto text-center space-y-12">
      <!-- Заголовок -->
      <h1 class="font-extrabold text-white text-4xl sm:text-5xl leading-tight">
        Новогодние подарки от <span class="text-orange-300">DNS</span>!
      </h1>

      <!-- Описание -->


      <!-- Основной блок -->
      <div class="bg-white p-8 rounded-2xl shadow-2xl space-y-8">
        <!-- HeroSection -->
        <HeroSection />
        <p class="uppercase font-extrabold text-orange-500 tracking-widest text-lg sm:text-xl">
          Специально для вас
        </p>
        <!-- Панель поиска -->
        <SearchPanel />

        <!-- Левый блок (категории, фильтры и т. д.) -->
        <LeftPanel />
      </div>
    </div>
  </div>
</template>


