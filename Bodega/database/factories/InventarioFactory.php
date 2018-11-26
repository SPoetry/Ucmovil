<?php

use Faker\Generator as Faker;

$factory->define(App\Inventario::class, function (Faker $faker) {
    return [
          'id_producto'=> $faker->unique()->randomNumber(3,true),
          'nombre' => $faker->sentence(1, false),
          'imagen' => $faker->imageUrl,
          'cantidad' => rand(1,100)
      ];
});
