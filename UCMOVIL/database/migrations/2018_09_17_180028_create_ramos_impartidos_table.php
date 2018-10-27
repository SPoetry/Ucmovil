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
            $table->increments('id_ramoimpartido');
            $table->string('id_asignatura', 10);
            $table->integer('id_profesor')->unsigned();
            $table->timestamps();
            $table->unique(['id_asignatura', 'id_profesor']);
            $table->foreign('id_asignatura')->references('id_asignatura')->on('asignaturas');
            $table->foreign('id_profesor')->references('id')->on('profesores');
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
