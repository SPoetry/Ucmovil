<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreateRamosImpartidosTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('ramos_impartidos', function (Blueprint $table) {
            $table->integer('id_asignatura')->references('id_asignatura')->on('asignaturas');
            $table->integer('id_profesor')->references('id_profesor')->on('profesores');
            $table->primary(['id_asignatura', 'id_profesor']);
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('ramos_impartidos');
    }
}
