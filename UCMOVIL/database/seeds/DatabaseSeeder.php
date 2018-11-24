<?php

use Illuminate\Database\Seeder;

class DatabaseSeeder extends Seeder
{
    /**
     * Seed the application's database.
     *
     * @return void
     */
     public function run()
     {
       $this->call('UserSeeder');
       $this->call('AlumnoSeeder');
       $this->call('ProfesoreSeeder');
       $this->call('SecretariaSeeder');
       $this->call('DirectoresCarreraSeeder');
       $this->call('MallaSeeder');
       $this->call('AsignaturaSeeder');
       $this->call('HorarioSeeder');
       $this->call('VersionRamoSeeder');
       $this->call('RamosActualeSeeder');
       //$this->call('HistorialSeeder');
       $this->call('NoticiaSeeder');
       //$this->call('PonderacionesRamoSeeder');
     }
}
