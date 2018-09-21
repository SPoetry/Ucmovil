<?php

use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;
use App\User;

class UserSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */

    public function run()
    {
      DB::table('users')->insert([
        'id' => '1',
        'email' => 'alumno@gmail.com',
        'password' => bcrypt('alumno'),
        'tipo' => 'alumno'
      ]);
      DB::table('users')->insert([
        'id' => '2',
        'email' => 'profesor@gmail.com',
        'password' => bcrypt('profesor'),
        'tipo' => 'profesor'
      ]);
      DB::table('users')->insert([
        'id' => '3',
        'email' => 'secretaria@gmail.com',
        'password' => bcrypt('secretaria'),
        'tipo' => 'secretaria'
      ]);
      DB::table('users')->insert([
        'id' => '4',
        'email' => 'directorcarrera@gmail.com',
        'password' => bcrypt('directorcarrera'),
        'tipo' => 'director_carrera'
      ]);
    }

}
